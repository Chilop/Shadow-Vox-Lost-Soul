using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector2 _moveInput;
    private bool _isGrounded;
    [SerializeField]private Transform virtualCamera;
    
    [Header("Movement Settings")]
    [SerializeField]private float speed = 5f;
    [SerializeField]private float jumpForce = 8f;
    [SerializeField]private Transform groundCheck;
    [SerializeField]private LayerMask groundLayer;

    private float _targetAngle;
    private float _angle;
    private float _smoothTime = 0.1f;
    private float _smoothVelocity;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {
        Vector3 Direction = new Vector3(_moveInput.x, 0, _moveInput.y).normalized;
        if (Direction.magnitude >= 0.1f)
        {
            _targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + virtualCamera.eulerAngles.y;
            _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _smoothVelocity, _smoothTime);
            transform.rotation = Quaternion.Euler(0f, _angle, 0f);
            
            Vector3 moveDirection = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;
            _rb.MovePosition(_rb.position + moveDirection.normalized * (speed * Time.fixedDeltaTime));
        }
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && _isGrounded)
        {
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, jumpForce, _rb.linearVelocity.z);
        }
    }
}
