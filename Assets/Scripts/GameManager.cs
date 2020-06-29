using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GetManager()
    {
        return currentManager;
    }
    static GameManager currentManager = null;

    public int playerLives = 3;
    public float respawnTime = 2;

    private bool isDead = false;

    private void Awake()
    {
        //if no gameManager is available
        //this becomes new gameManager
        if (currentManager == null)
        {
            currentManager = this;
            DontDestroyOnLoad(gameObject);
            //calls PlayerDies when OnPlayerDeath event is used
            Health.OnPlayerDeath += PlayerDies; 
        }
        else
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        //set currentManager to null when destroyed
        //prevents both managers being in scene 
        if (currentManager == this)
        {
            currentManager = null;
            //stops calling PlayerDies when OnPlayerDeath event
            Health.OnPlayerDeath -= PlayerDies;
        }
    }

    public void PlayerRespawn()
    {
        playerLives--;
        if (playerLives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            isDead = false;
        }
        else
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("Menu");
        }
    }

    public void PlayerDies()
    {
        if (!isDead)
        {
            Invoke("PlayerRespawn", respawnTime);
            isDead = true;
        }
    }
}
