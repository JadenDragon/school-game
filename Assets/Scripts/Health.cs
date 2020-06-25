using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth = 100;
    public int maxHealth = 100;
    public const int addHealth = 5;

    //subtract damage from health on call
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Taking " + damage + " HP damage! Health = " + currentHealth+"HP");
        if(currentHealth <= 0)
        {
            GetComponent<Movement>().moveSpeed = 0;
            Debug.Log("YOU DIED!");
        }
    }

    public void GainHealth(int heal = addHealth)
    {
        //health regenerated is the same value as addHealth which is dependant on the regen value of object/prefab
        
        if (currentHealth < maxHealth)
        {
            currentHealth += heal;
            //checks if health after regen is not greater than max health
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }

            Debug.Log("Gain " + heal + " HP ! Health = " + currentHealth + "HP");
        }  else if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            Debug.Log("Gain " + heal + " HP ! Health = " + currentHealth + "HP");
        }
    }
}
