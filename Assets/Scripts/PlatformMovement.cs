using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Vector3[] destinations;
    public int n_destinations;

    private Vector3 currentDestination;

    public float tolerance;
    public float moveSpeed;
    public float delay;

    private float delayStart;

    public bool automatic;

    // Start is called before the first frame update
    void Start()
    {
        if (destinations.Length > 0)
        {
            currentDestination = destinations[0];
        }
        tolerance = moveSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != currentDestination)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }
    }

    void MovePlatform()
    {
        Vector3 distance = currentDestination - transform.position;
        transform.position += (distance / distance.magnitude) * moveSpeed * Time.deltaTime;
        if (distance.magnitude < tolerance)
        {
            transform.position = currentDestination;
            delayStart = Time.time;
        }
    }

    void UpdateTarget()
    {
        if (Time.time - delayStart > delay)
        {
            NextDestination();
        }
    }

    void NextDestination()
    {
        n_destinations++;
        if (n_destinations >= destinations.Length)
        {
            n_destinations = 0;
        }
        currentDestination = destinations[n_destinations];
    }
}
