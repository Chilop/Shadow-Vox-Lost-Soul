using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Vector2 direction;
    
    public Vector2 Direction => direction;

    public void SetDirection(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
}
