using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool interactable = false;

    public Rigidbody coinPrefab;
    public Transform spawner;

    // Update is called once per frame
    void Update()
    {
        if(interactable == true && Input.GetKeyDown(KeyCode.Space))
        {
            print("Item obtained");

            Rigidbody coinInstance;
            coinInstance = Instantiate(coinPrefab, spawner.position, spawner.rotation) as Rigidbody;
            coinInstance.AddForce(spawner.up * 10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = true;
            print("Collected!");


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            interactable = false;
            print("Take me please!");
        }
    }
}
