using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontalMove : MonoBehaviour
{
    public Rigidbody rb;
    public float startPosition = 0.372f;
    public float endPosition = 8.372f;
    [Range(0f, 1f)] public float lerpPercent = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //move platform using it's transform
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //moves the platform from startPosition to endPosition
        if (transform.position.y == startPosition)
        {
            //transform.position = new Vector3(0f, endPosition, 0f);
            Vector3 destination = new Vector3(0f, endPosition, 0f);
            rb.position =  Vector3.Lerp(transform.position, destination, lerpPercent);
            
        }
        else if (transform.position.y == endPosition)
        {
            //transform.position = new Vector3(0f, startPosition, 0f);
            Vector3 returnDestination = new Vector3(0f, startPosition, 0f);
            rb.position = Vector3.Lerp(transform.position, returnDestination, lerpPercent);
        }
        //rb.MovePosition(transform.position * rb.velocity.y * Time.deltaTime);
    }
}
