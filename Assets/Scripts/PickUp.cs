using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public enum PickUpType
{
    HEALTH,
    MONEY,
    KEY
}
public class PickUp : MonoBehaviour
{
    public PickUpType type;
    public int amount;
    public float RotationSpeed = 50f;
    public PlayerController player;

    private string nextScene;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
             if (type == PickUpType.HEALTH)
            {
                Health playerHealth =  other.GetComponentInParent<Health>();
                playerHealth.GainHealth(amount);
                Destroy(gameObject);
                Debug.Log("Player got health");
            }
            else if (type == PickUpType.MONEY)
            {
                ScoreManager playerScore = other.GetComponentInParent<ScoreManager>();
                //playerScore.AddScore(amount);
                ScoreManager.theScore += amount;
                Debug.Log("score " + amount);
                Destroy(gameObject);
            }
             else if (type == PickUpType.KEY)
            {
                //SceneManager.LoadScene(nextScene);
            }
        }
    }

}
