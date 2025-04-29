using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager :  Singleton<IInputSource>,IInputSource
{
    [SerializeField] private PlayerInput playerInput;
    
    private Vector2 direction;
    
    public Action OnLeverButtonPressed { get; set; }
    public Vector2 Direction => direction;
    
    public void SetDirection(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        ActionButtons();
    }

    private void ActionButtons()
    {
        if (playerInput.actions["Interact"].WasPressedThisFrame())
        {
            OnLeverButtonPressed?.Invoke();
        }
    }

    
}
