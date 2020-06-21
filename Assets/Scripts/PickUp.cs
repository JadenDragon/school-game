using UnityEngine;


public enum PickUpType
{
    HEALTH,
    MONEY,
}
public class PickUp : MonoBehaviour
{
    public PickUpType type;
    public int amount;
    public GameObject player;

    private void Start()
    {

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
            /*else if (type == PickUpType.MONEY)
            {
                return 0;
            }*/
        }
    }
}
