using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    // Update is called once per frame
    void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        //adds horizontal & vertical mouse values into mouseX & mouseY
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

    }
}
