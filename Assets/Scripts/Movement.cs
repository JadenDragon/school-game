using Cinemachine.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public BoxCollider playerCollider;
    public float moveSpeed = 5f;

    //private GameObject enemy;
    private Enemy enemyScript;

    private RaycastHit hit;
    private Ray rayInfo;
    public float rayDistance = 4f;

    public SphereCollider ItemDetect;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<BoxCollider>();
        playerCollider.size = new Vector3(0f, 1.1f, 0f);
        playerCollider.center = new Vector3(0f, playerCollider.size.y/2, 0);

        //enemy = GameObject.Find("Capsule");
        //enemyScript = enemy.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //print(moveHorizontal);

        Vector3 playerMovement = new Vector3(moveHorizontal, 0f, moveVertical);

        transform.Translate(playerMovement * Time.deltaTime * moveSpeed);*/

        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            //decreases enemy health when player presses spacebar
            enemyScript.enemyHealth--;
        }*/

        rayInfo = new Ray(transform.position + new Vector3(0f, playerCollider.center.y, 0f), transform.forward);
        Debug.DrawRay(rayInfo.origin, rayInfo.direction * rayDistance, Color.red);  

        if(Physics.Raycast(rayInfo, out hit))
        {
            if(hit.distance < rayDistance)
            {
                //print("touching tips");
                if(hit.collider.gameObject.tag == "Enemy")
                {
                    print("WOAH ENEMY");
                }
            }
        }
        PlayerMovement();

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyScript = collision.gameObject.GetComponent<Enemy>();
            //decreases enemy health on collision
            enemyScript.enemyHealth--;
        }
    }

    //movement function for ease
    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }
}
