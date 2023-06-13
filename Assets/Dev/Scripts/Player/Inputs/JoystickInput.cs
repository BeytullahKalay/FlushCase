using UnityEngine;

public class JoystickInput : MonoBehaviour,IPlayerInput
{
    [SerializeField] private DynamicJoystick floatingJoystick;
    
    public Vector2 MoveInput { get; set; }
    public bool IsInputDetected { get; set; }

    private void Update()
    {
        MoveInput = new Vector2(floatingJoystick.Horizontal, floatingJoystick.Vertical);
        IsInputDetected = MoveInput.magnitude > 0;
    }
    
    public float GetRotateAngle()
    {
        var dir = new Vector2(MoveInput.x, MoveInput.y);
        dir = dir.normalized;
        var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;
        return angle;
    }

}
