using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
     private Rigidbody _rb; 
     
     private float _movementX;
     private float _movementY;
     private float _movementZ;
     
     private float speed = 2; 
     private float jumpForce = 5f;
     
     void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
     
     void OnMove(InputValue movementValue)
        {
     // Convert the input value into a Vector2 for movement.
            Vector2 movementVector = movementValue.Get<Vector2>();
    
     // Store the X and Y components of the movement.
            _movementX = movementVector.x; 
            _movementY = movementVector.y; 
        }
    
     // FixedUpdate is called once per fixed frame-rate frame.
     private void FixedUpdate() 
        {
     // Create a 3D movement vector using the X and Y inputs.
            Vector3 movement = new Vector3 (_movementX, 0.0f, _movementY);
    
     // Apply force to the Rigidbody to move the player.
            _rb.AddForce(movement * speed); 
        }

        void Onjump(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _rb.AddForce(Vector3.up * jumpForce);
            }
        }
}
