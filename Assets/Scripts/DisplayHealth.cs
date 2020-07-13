using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHealth : MonoBehaviour
{
    // Start is called before the first frame update
    //RectTransform m_RectTransform;
    private Health playerHealth;
    public bool heal;
    public bool damage;


    void Start()
    {
        playerHealth =  GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        //UpdateHealth();
            playerHealth.OnHealthChange += UpdateHealth;
    }

    private void Update()
    {
        UpdateHealth();
    }

    private void OnDestroy()
    {
        playerHealth.OnHealthChange -= UpdateHealth;
        
    }

    void UpdateHealth()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.localScale = new Vector3(playerHealth.currentHealth/playerHealth.maxHealth, 1, 1);
        Debug.Log("im here");
        damage = false;
    }

    /*void IncreaseHealth()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.localScale = new Vector3(0.5f, 1, 1);
        Debug.Log("Boeing");
    }*/
}
