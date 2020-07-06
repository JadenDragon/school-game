using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2f;
    public bool isGrounded;
    Rigidbody rb;

    private void Start()
    {
//        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, 2f, 0f);
    }

    private void OnCollisionStay(Collision collision)
    {
        rb = collision.rigidbody;
        isGrounded = true;
        Debug.Log("rb name = " +rb.name);
    }

    private void Update()
    {
        if (isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
