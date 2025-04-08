using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector2 _moveInput;
    private bool _isGrounded;
    
    [Header("Movement Settings")]
    [SerializeField]private float speed = 5f;
    [SerializeField]private float jumpForce = 8f;
    [SerializeField]private Transform groundCheck;
    [SerializeField]private LayerMask groundLayer;

    private float _targetAngle;
    private float _angle;
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
        Vector3 moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y).normalized;
        _rb.MovePosition(transform.position + moveDirection * (speed * Time.fixedDeltaTime));
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
