using UnityEngine;
using UnityEngine.UI;

public class DisplayLives : MonoBehaviour
{
    int livesAmount;

    // Start is called before the first frame update
    void Start()
    {
        //get amount of lives from GameManager
        livesAmount = GameManager.GetManager().playerLives;
        ShowLivesText();
        Health.OnPlayerDeath += ShowLivesText;
    }

    private void OnDestroy()
    {
        Health.OnPlayerDeath -= ShowLivesText;
    }

    void ShowLivesText()
    {
        GetComponent<Text>().text = "Lives: " + livesAmount;
        livesAmount--;
    }
}
