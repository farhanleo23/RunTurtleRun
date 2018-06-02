using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private float LANE_DISTANCE = 5.0f;

    private CharacterController controller;
  //  private float jumpForce = 4.0f;
   // private float gravity = 12.0f;
    private float verticalVelocity;
    private float speed = 3.0f;

    private int desiredlane = 1; // 0 = left, 1 = middle, 2 = right


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // gather where we should be in lane
        if (TurtleMovement.Instance.SwipeLeft)
            Movelane(false);
        if (TurtleMovement.Instance.SwipeRight)
            Movelane(true);
        
        // where should we be in future
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredlane == 0)
            targetPosition += Vector3.left * LANE_DISTANCE;
        else if (desiredlane == 2)
            targetPosition += Vector3.right * LANE_DISTANCE;

        // calculating move delta
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;
        moveVector.y = -0.1f;
        moveVector.z = speed;

        // move the turtle
        controller.Move(moveVector * Time.deltaTime);

        
    }


    private void Movelane(bool goingRight)
    {
        desiredlane += (goingRight) ? 1 : -1;
        desiredlane = Mathf.Clamp(desiredlane, 0, 2);
    }

}
