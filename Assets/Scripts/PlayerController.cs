using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private CharacterController playerControl;
    public Vector3 playerVelocity;
    //public bool isGrounded;
    public Rigidbody rb;

    [SerializeField] private float moveForce = 5f;
    [SerializeField] private float movementSpeed = 3.0f;
    [SerializeField] private float jumpHeight = 5.0f;
    //[SerializeField] private float gravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        //playerControl = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerVelocity.y <= 0)
            playerVelocity.y = 0;

        Vector3 directMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //resets player isGrounded to true at the start of each update
        if (IsGrounded())
        {
            Vector3 baseVelocity = Vector3.zero;
            playerVelocity.y = rb.velocity.y;
            rb.velocity = directMovement * movementSpeed + playerVelocity;
        }
         else
            rb.AddForce(directMovement * moveForce);

        if (Input.GetButtonDown("Jump") && IsGrounded())
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * Physics.gravity.y);

        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
    }

    bool IsGrounded()
    {
        //characters butthole position
        Vector3 origin = transform.position;
        Vector3 direction = new Vector3(0f, -1f, 0f);
        float maxDistance = 1.1f;   //max distance that ray checks
        RaycastHit rayHitInfo;

        if (Physics.Raycast(origin, direction, out rayHitInfo, maxDistance))
            return true;

        return false;
    }
}
