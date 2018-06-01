using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour {

    public static TurtleMovement Instance { get; set; }


    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 swipeDelta, startTouch;

    public bool Tap { get { return tap; }}
    public Vector2 SwipeDelta { get{ return swipeDelta; }}
    public bool SwipeLeft { get { return swipeLeft; }}
    public bool SwipeRight { get { return swipeRight; }}
    public bool SwipeUp { get { return SwipeUp; }}
    public bool SwipeDown{ get { return swipeDown; }}


    private void Awake()
    {
        Instance = this;
    }
}
