using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHealth : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform m_RectTransform;
    public Health playerHealth;
    
    void Start()
    {
        playerHealth = GetComponent<Health>();
        UpdateHealth();
    }

    private void Update()
    {
        playerHealth.OnHealthChange += UpdateHealth;
    }

    private void OnDestroy()
    {
        playerHealth.OnHealthChange -= UpdateHealth;
    }

    void UpdateHealth()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.localScale = new Vector3(playerHealth.currentHealth, 1, 1);
        Debug.Log("im here");
    }
}
