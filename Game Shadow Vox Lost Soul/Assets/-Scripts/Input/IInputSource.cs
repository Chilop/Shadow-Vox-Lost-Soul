using System;
using UnityEngine;

public interface IInputSource
{
   Action OnLeverButtonPressed { get; set; }
}
