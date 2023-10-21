using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float forceMagnitude;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Button _kickButton;
    [SerializeField] private GameObject puck;
    [SerializeField] private float pushRange;
    [SerializeField] private Button slideButton;
    private bool isSliding = false;
    private bool canPerformSlideDash = true;
    private float dashDistance = 5f;
    private Vector3 dashDirection;
    private bool _isKicking;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (slideButton != null)
        {
            dashDirection = transform.forward;
            slideButton.onClick.AddListener(PerformSlideDash);
        }
        _kickButton.onClick.AddListener(StartKicking);
    }

    void PerformSlideDash()
    {
        if (!isSliding && canPerformSlideDash)
        {
            isSliding = true;
            dashDirection = transform.forward;

            _animator.SetBool("IsDashing", true);

            Vector3 targetPosition = transform.position + dashDirection * dashDistance;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, dashDirection, out hit, dashDistance))
            {
                targetPosition = hit.point;
            }

            StartCoroutine(MoveCharacter(targetPosition));
        }
    }


    IEnumerator MoveCharacter(Vector3 targetPosition)
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        transform.position = targetPosition;
        isSliding = false;
        _animator.SetBool("IsDashing", false);
    }


    private void FixedUpdate()
    {
        Vector3 inputDirection = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
        inputDirection.Normalize();

        Vector3 movement = inputDirection * _moveSpeed;
        movement.y = _rigidbody.velocity.y;

        if (!_isKicking)
        {

            if (inputDirection == Vector3.zero)
            {
                movement = Vector3.Lerp(_rigidbody.velocity, Vector3.zero, Time.fixedDeltaTime * 10f);
            }
            _rigidbody.velocity = movement;
        }

        if (inputDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);
            _rigidbody.MoveRotation(targetRotation);
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("IsKicking", false);
        }
    }


    private void StartKicking()
    {
        float distanceToPuck = Vector3.Distance(transform.position, puck.transform.position);

        if (distanceToPuck <= pushRange && !_animator.GetBool("IsKicking"))
        {
            _animator.SetBool("IsKicking", true);
            ApplyPushForce();
        }
    }

    private void ApplyPushForce()
    {
        Physics.IgnoreCollision(puck.GetComponent<Collider>(), GetComponent<Collider>(), true);


        Rigidbody puckRigidbody = puck.GetComponent<Rigidbody>();
        if (puckRigidbody != null)
        {
            puckRigidbody.AddForce(transform.forward * forceMagnitude, ForceMode.Impulse);
        }
    }

    private void EnablePuckCollision()
    {
        Physics.IgnoreCollision(puck.GetComponent<Collider>(), GetComponent<Collider>(), false);
    }

}