using System;
using UnityEngine;

public class Lever : SwitchObject
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InputManager.Source.OnLeverButtonPressed += AlternateState;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InputManager.Source.OnLeverButtonPressed -= AlternateState;
        }
    }
}
