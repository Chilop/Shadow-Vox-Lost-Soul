using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
     [SerializeField] private Rigidbody _rb; 
     private float _movementX;
     private float _movementY;
     private float _movementZ;
     
     [SerializeField] private float speed = 3f; 
     [SerializeField] private float jumpForce = 5f;
     
     [SerializeField] private Vector3 moveDirection;
     
     void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
     
     public void OnMove(InputAction.CallbackContext context)
        {
     
            Vector2 movementVector = context.ReadValue<Vector2>();
    
     
            _movementX = movementVector.x; 
            _movementY = movementVector.y; 
            
            Debug.Log(context.ReadValue<Vector2>());
        }
    
     
     private void FixedUpdate()
        {
         moveDirection = new Vector3(_movementX,0, _movementY);
            _rb.AddForce(moveDirection * speed);
        }

        public void OnJump(InputAction.CallbackContext ctx)
        {
                _rb.AddForce(Vector3.up * jumpForce);
                Debug.Log(ctx.performed);
        }
}
