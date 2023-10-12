using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour

{
    private Rigidbody _rigidbody;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float forceMagnitude;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Button _kickButton;
    [SerializeField] private Button dashButton;
    [SerializeField] private TrailRenderer tr;

    private bool _isKicking;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _kickButton.onClick.AddListener(StartKicking);
        dashButton.onClick.AddListener(StartDashing);


    }


    private void FixedUpdate()
    {

        if (isDashing)
        {
            return;
        }

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
            _animator.SetBool("IsDashing", false);
        }

        
    }

    private void StartKicking()
    {
        if (!_isKicking)
        {
            _animator.SetBool("IsKicking", true);
            ApplyPushForce();
        }
    }

    private void StartDashing()
    {
        if (!isDashing)
        {
            _animator.SetBool("IsDashing", true);
            ApplyPushForce();
        }
    }

    private void ApplyPushForce()
    {
        Vector3 forceDirection = transform.forward;
        _rigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
    }

    private IEnumerator Dash()
    {

        canDash = false;
        isDashing = true;
        _rigidbody.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }
}