using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : ICharacterAnimation
{

    Animator _animator;
    

    public CharacterAnimation(Animator animator)
    {
        _animator = animator;
    }


    public void RunAnimation(float moveSpeed)
    {

        float mathValue = Mathf.Abs(moveSpeed);
        

        if (_animator.GetFloat("moveSpeed") == mathValue)
            return;

        _animator.SetFloat("moveSpeed", mathValue);
    }

    public void JumpAnimation(bool isJump)
    {
        if (_animator.GetBool("isJump") == isJump)
            return;

        _animator.SetBool("isJump", isJump);
    }
}
