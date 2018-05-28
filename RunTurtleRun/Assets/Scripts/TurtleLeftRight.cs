using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleLeftRight : MonoBehaviour {

    public float moveSpeed = 0.1f;
    public GameObject Character;

    private Rigidbody characterBody;
    private float screenWidth;

	// Use this for initialization
	void Start () {
        screenWidth = Screen.width;
        characterBody = Character.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
        int i = 0;
        //loop over every touch found
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > screenWidth / 2)
            {
                //move right
                RunCharacter(1.0f);
            }
            if (Input.GetTouch(i).position.x < screenWidth / 2)
            {
                //move left
                RunCharacter(-1.0f);
            }
            ++i;
        }

	}

    void FixedUpdate()
    {
    #if UNITY_EDITOR
        RunCharacter(Input.GetAxis("Horizontal"));
    #endif


    }

    private void RunCharacter(float HorizontalInput) {

        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

        // Move object across XY plane
        transform.Translate(-touchDeltaPosition.x * moveSpeed, -touchDeltaPosition.y * moveSpeed, 0);

      //  characterBody.AddForce(new Vector3(HorizontalInput * moveSpeed * Time.deltaTime, 0, 0));
    }
}
