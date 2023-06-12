using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private IPlayerInput _input;
    
    private const string MOVEINPUT = "MoveInputValue";
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _input = GetComponent<IPlayerInput>();
    }

    private void Update()
    {
        _animator.SetFloat(MOVEINPUT,_input.MoveInput.magnitude);
    }
}
