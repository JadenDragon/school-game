using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpItem : MonoBehaviour
{
    //using Transform cause we are lerping objects
    /*[SerializeField]
    private Transform startLerp;*/
    [SerializeField]
    private Transform endLerp;

    public Collision collision;
    private bool hasCollided = false;

    //percentage of distance an object moves between start to end
    //range of percentage between 0 - 100%
    [SerializeField]
    [Range(0f, 1f)]
    private float percentLerp = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (hasCollided)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, endLerp.position, percentLerp);
            Debug.Log(endLerp.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HERE A"+ collision.collider.GetType());
        if (collision.collider is BoxCollider && collision.gameObject.tag == "Player")
        {

            Debug.Log ( "HERE  BB");
            //transform.position = Vector3.Lerp(startLerp.position, endLerp.position, percentLerp);
            endLerp = collision.transform;
            hasCollided = true;
        }
    }
}
