using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody _rb;
    private bool _jump;
    private Vector3 _movementForce;
    
    [SerializeField] private float _jumpMultiplier = 10f;
    [SerializeField] private float _moveSpeed = 10f; 


    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Jump() 
    {
        if (_jump)
        {
            _rb.AddForce(Vector3.up * _jumpMultiplier);
            _jump = false;
        }
    }

    private void Move() 
    {
        _rb.AddForce(_movementForce * _moveSpeed);
    }

    private void ReadInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movementForce = new Vector3(horizontal, 0f, vertical);

        if (Input.GetButtonDown("Jump") && IsGrounded())
            _jump = true;
    }

    //TODO: Add your own checks for if the player is grounded, e.g. Collider stuff.
    private bool IsGrounded() => true;
    
 
}
