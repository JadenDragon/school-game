using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform player;
    public float triggerDistance = 1;
    public int damageAmount = 5;

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
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }

        
    }
}
