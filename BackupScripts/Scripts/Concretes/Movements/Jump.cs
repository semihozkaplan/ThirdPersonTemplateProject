using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : IJump
{
    CharacterController _characterController;


    public Jump(CharacterController characterController)
    {
        _characterController = characterController;
    }

    public void JumpAndFallAction(float yVelocity)
    {  

        _characterController.Move(new Vector3(0f, yVelocity, 0f) * Time.deltaTime);
                    
    }
}
