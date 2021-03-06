﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public Transform player;
    public float triggerDistance = 1;
    public int damageAmount = 5;
    public int healAmount = 5;

    private GameObject other;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = (player.position - transform.position).magnitude;
        //destroy bomb when player is in bomb range to damage player
        if (distance <= triggerDistance)
        {
            Debug.Log("BOOM! EXPLODE!");
            Destroy(gameObject);
            
            Health playerHealth = player.gameObject.GetComponent<Health>();
            if (this.gameObject.CompareTag("Damaging"))
            {
                playerHealth.TakeDamage(damageAmount);
            }
            else {
                playerHealth.GainHealth(healAmount);
                Debug.Log("health gained!");
            }
        }
    }
}
