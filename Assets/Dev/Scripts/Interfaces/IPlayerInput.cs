
using UnityEngine;

public interface IPlayerInput
{
    public Vector2 MoveInput { get;}
    public float GetRotateAngle();
    public bool IsInputDetected { get; }
}
