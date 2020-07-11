using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLives : MonoBehaviour
{
    int lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = GameManager.GetManager().playerLives;
        ShowLivesText();
        Health.OnPlayerDeath += ShowLivesText;
    }

    private void OnDestroy()
    {
        Health.OnPlayerDeath -= ShowLivesText;
    }

    void ShowLivesText() {
        GetComponent<Text>().text = "Lives: " + lives;
        lives--;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
