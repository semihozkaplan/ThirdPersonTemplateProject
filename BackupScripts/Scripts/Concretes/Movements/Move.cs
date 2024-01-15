using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Move : IMove
{
    CharacterController _controller;
    IEntityController _entityController;
    Vector3 _direction;   
    float _speed;
    private float turnSmoothTime = 0.15f;
    float turnSmoothVelocity;

    //Mouse Camera
    Transform _cam;

    public Move(CharacterController controller, float speed, IEntityController entityController, Transform cam)
    {
        _controller = controller;       
        _speed = speed;
        _entityController = entityController;
        _cam = cam;
    }

    public float Movement(float horizontal, float vertical)
    {
        _direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (_direction.magnitude >= 0.1f)
        {
            // Atan2 calculates the angle between x and z axis. We multipled Rad2Deg to convert this value to degree
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(_entityController.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            _entityController.transform.rotation = Quaternion.Euler(0f,angle,0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _controller.Move(moveDir.normalized* _speed * Time.deltaTime);
            return _direction.magnitude;
        }


        return _direction.magnitude;
    }


}


