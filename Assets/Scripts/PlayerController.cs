using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float forceMagnitude;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Button _kickButton; // Reference to your UI button
    private bool _isKicking;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _kickButton.onClick.AddListener(StartKicking); // Attach the method to the button click event
    }

    private void FixedUpdate()
    {
        Vector3 inputDirection = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
        inputDirection.Normalize();

        Vector3 movement = inputDirection * _moveSpeed;
        movement.y = _rigidbody.velocity.y;

        if (!_isKicking)
        {
            // Smoothly transition to zero velocity if there's no input
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
        if (!_isKicking)
        {
            _animator.SetBool("IsKicking", true);
            ApplyPushForce();
        }
    }

    private void ApplyPushForce()
    {
        Vector3 forceDirection = transform.forward;
        _rigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
    }
}
