using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float RotationSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //rotates object around x-axis
        transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider is BoxCollider && collision.gameObject.tag == "Player")
        {
            //destroy object 0.2 seconds after collision with player
            Destroy(gameObject, 3f);
        }
    }
}
