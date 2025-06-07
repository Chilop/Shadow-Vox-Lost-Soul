using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    private Vector2 _moveInput;
    private bool _isGrounded;

    [Header("Movimiento")]
    [SerializeField] public float speed = 5f;
    [SerializeField] public float jumpForce = 7f;

    [Header("Suelo")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Cámara")]
    [SerializeField] private Transform virtualCamera;

    private float _targetAngle;
    private float _angle;
    private float _smoothVelocity;
    private float _smoothTime = 0.1f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(_moveInput.x, 0f, _moveInput.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Rotación hacia dirección del movimiento + cámara
            _targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + virtualCamera.eulerAngles.y;
            _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _smoothVelocity, _smoothTime);
            transform.rotation = Quaternion.Euler(0f, _angle, 0f);

            // Movimiento hacia dirección deseada
            Vector3 moveDir = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;
            Vector3 velocity = moveDir.normalized * speed;
            velocity.y = _rb.linearVelocity.y;

            _rb.linearVelocity = velocity;
        }
        else
        {
            // Mantener solo la componente vertical si no se mueve
            _rb.linearVelocity = new Vector3(0f, _rb.linearVelocity.y, 0f);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        Debug.Log("Move input: " + _moveInput);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && _isGrounded)
        {
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, jumpForce, _rb.linearVelocity.z);
            _animator.SetTrigger("Jump");
        }
    }

    private void UpdateAnimator()
    {
        float horizontalSpeed = new Vector3(_rb.linearVelocity.x, 0f, _rb.linearVelocity.z).magnitude;
        _animator.SetFloat("Speed", horizontalSpeed);
        _animator.SetBool("IsGrounded", _isGrounded);
        Debug.Log($"Speed: {horizontalSpeed} | IsGrounded: {_isGrounded}");
    }
}
