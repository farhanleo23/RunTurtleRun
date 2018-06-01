using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{

    public static TurtleMovement Instance { get; set; }


    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 swipeDelta, startTouch;

    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return SwipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        // checking for inputs
        if (Input.touches.Length > 0)
        {
            Debug.Log("hello");
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }
        }

        // calculating distance

        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            // checking for mobile distance
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
        }

        float x = swipeDelta.x;
        float y = swipeDelta.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            //left or right
            if (x < 0)
                swipeLeft = true;
            else
                swipeRight = true;
        }
        else
        {
            if (y < 0)
                swipeDown = true;
            else
                swipeUp = true;
        }


    }
}
