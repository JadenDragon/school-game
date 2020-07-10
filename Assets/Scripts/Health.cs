using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    //creates an event for other scripts to listen
    //only triggered by this script
    public static event Action OnPlayerDeath;
    public event Action OnHealthChange;

    public int currentHealth = 100;
    public int maxHealth = 100;
    public const int addHealth = 5;

    //subtract damage from health on call
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Taking " + damage + " HP damage! Health = " + currentHealth+"HP");
        if (OnHealthChange != null)
            OnHealthChange();

        if(currentHealth <= 0)
        {
            GetComponent<SimplePhysicsControls>().moveSpeed = 0;
            onDeath();
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

     void onDeath()
    {
        Debug.Log("YOU DIED!");
        //GameManager.GetManager().PlayerDies();

        //triggers event for every object that listens to it
        OnPlayerDeath?.Invoke();
    }
}
