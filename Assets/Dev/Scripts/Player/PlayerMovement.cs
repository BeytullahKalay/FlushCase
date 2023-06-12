using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotateSpeed = 5f;

    private IPlayerInput _input;

    private void Awake()
    {
        _input = GetComponent<IPlayerInput>();
    }


    private void FixedUpdate()
    {
        if (!_input.IsInputDetected) return;

        HandlePosition();

        HandleRotation();
    }

    private void HandlePosition()
    {
        transform.position +=
            new Vector3(_input.MoveInput.x, 0, _input.MoveInput.y) * (speed * Time.fixedDeltaTime);
    }

    private void HandleRotation()
    {
        var rot = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, _input.GetRotateAngle(), 0),
            rotateSpeed * Time.fixedDeltaTime);

        transform.rotation = rot;
    }
}