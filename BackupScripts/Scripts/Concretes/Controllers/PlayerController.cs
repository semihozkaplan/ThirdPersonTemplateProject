using MasterGame3D.Abstracts.Inputs;
using MasterGame3D.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IEntityController
{

    IMove _move;
    IJump _jump;
    IInput _input;
    CharacterController _characterController;
    ICharacterAnimation _characterAnimation;
    float _animMoveSpeed;
    float _horizontal;
    float _vertical;
    [SerializeField] private float _speed = 12f;

    //Jump
    [SerializeField] private float _jumpHeight = 15f;
    private Vector3 _yVelocity;
    private bool _isJump;

        
    //Gravity
    [SerializeField] float gravityValue = 5f;
    
    //Camera Mouse
    [SerializeField] Transform _camTransform;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();  
        _input = new PcInput();       
        _move = new Move(_characterController, _speed, this, _camTransform);
        _jump = new Jump(_characterController);
        _characterAnimation = new CharacterAnimation(this.transform.GetChild(0).GetComponent<Animator>());
    }


    private void Update()
    {
        _horizontal = _input.Horizontal;
        _vertical = _input.Vertical;              

        //Move Animation
        _animMoveSpeed = _move.Movement(_horizontal, _vertical);
        _characterAnimation.RunAnimation(_animMoveSpeed);

        //Gravity and Jumping
        if (_characterController.isGrounded)
        {
            _yVelocity.y = -1;

            if (_input.Jump)
            {
                _yVelocity.y = _jumpHeight;                
            }           
        }

        _characterAnimation.JumpAnimation(_isJump);

        _yVelocity.y -= gravityValue * Time.deltaTime;
        _jump.JumpAndFallAction(_yVelocity.y);        

    }


}
