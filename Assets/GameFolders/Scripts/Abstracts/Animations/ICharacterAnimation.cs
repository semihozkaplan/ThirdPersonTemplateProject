using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterAnimation 
{
    void RunAnimation(float moveSpeed);
    void JumpAnimation(bool isJump);
}
