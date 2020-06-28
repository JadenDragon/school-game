using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController playerControl;
    private Vector3 playerVelocity;
    private bool isGrounded;

    [SerializeField] private float movementSpeed = 3.0f;
    [SerializeField] private float jumpHeight = 5.0f;
    [SerializeField] private float gravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalMove = Input.GetAxis("Horizontal");
        //float verticalMove = Input.GetAxis("Vertical");

    //resets player isGrounded to true at the start of each update
    isGrounded = playerControl.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 directMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerControl.Move(directMovement * Time.deltaTime * movementSpeed);

        if (directMovement != Vector3.zero)
        {
            gameObject.transform.forward = directMovement;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        playerControl.Move(playerVelocity * Time.deltaTime);
    }
}
