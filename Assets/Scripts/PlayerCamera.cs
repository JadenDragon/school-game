using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    public float cameraSpeed = 5;

    Quaternion cameraRestPosition;
    Quaternion currentY_Rotation;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        cameraRestPosition = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //NOTE: rotations are applied from right to left
        //store the rotation around the Yaxis
        Quaternion playerY_Rotation = Quaternion.Euler(0f, target.rotation.eulerAngles.y, 0);
        currentY_Rotation = Quaternion.Slerp(currentY_Rotation, playerY_Rotation, cameraSpeed * Time.deltaTime);

        transform.position = target.position + target.rotation * offset;
        transform.rotation = currentY_Rotation * cameraRestPosition;
    }
}
