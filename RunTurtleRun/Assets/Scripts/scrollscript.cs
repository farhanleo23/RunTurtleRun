using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollscript : MonoBehaviour
{

    float scrollspeed = -5f;
    Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollspeed, 20);
        //transform.position = Vector3.MoveTowards(startPos, s,  Time.deltaTime);
        transform.position = startPos + Vector3.forward * newPos;

        GameObject go = GameObject.Find("temp");
        /*if (go != null)
        {
            newPos = go.transform
        }
        else
        {
            Debug.Log("House not found");*/
    }

}
