using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform playerTransform;

    private Vector3 camOffset;

    [Range(0.01f, 1f)]
    public float smooth;

    public bool lookAtTarget = false;
    public bool RotateAroundPlayer = true;
    public float rotSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotSpeed, Vector3.up);

            camOffset = camTurnAngle * camOffset;
        }

        Vector3 newPosition = playerTransform.position + camOffset;

        transform.position = Vector3.Slerp(transform.position, newPosition, smooth);

        if (lookAtTarget || RotateAroundPlayer)
            transform.LookAt(playerTransform);
    }
}
