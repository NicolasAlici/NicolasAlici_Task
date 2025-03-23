using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerModel : MonoBehaviour
{
    private PlayerController _player;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<PlayerController>();
    }
    
    public void MovementAnim(InputAction.CallbackContext context)
    {
        _animator.SetBool("isWalking", true); //Setting the isWalking bool of the animator on true

        if (context.canceled)
        {
            _animator.SetBool("isWalking", false); //If its canceled then isWalking = false
            _animator.SetFloat("LastInputX", _player.moveDir.x);
            _animator.SetFloat("LastInputY", _player.moveDir.y);
        }
    
        _animator.SetFloat("InputX", _player.moveDir.x);
        _animator.SetFloat("InputY", _player.moveDir.y);
    }
}
