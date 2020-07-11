using UnityEngine;

public class DisplayHealth : MonoBehaviour
{
    Health playerHealth;
    //the variable that controls if the player should start at 100% health or less
    //change to false if player should start at 100% health
   int startHealthy = 1;
   
  

    // Start is called before the first frame update
    void Start()
    {

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        playerHealth.OnHealthChange += UpdateHealthBar;
        Debug.Log("hello");
        UpdateHealthBar();


    }

    private void OnDestroy()
    {
      playerHealth.OnHealthChange -= UpdateHealthBar;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateHealthBar()
    {

        /* //rt.localScale = new Vector3((float)playerHealth.currentHealth / (float)100, 1f, 1);
         if (startHealthy == 1)
         {
             //start with 100% health
             rt.localScale = new Vector3(1f, 1f, 1);
             //  To disable the start function 
             startHealthy += 1;
         }
         else
         {
             // start with current health
             rt.localScale = new Vector3((float)70.0 / (float)100, 1f, 1);

         }

         
         rt.localScale = new Vector3((float)playerHealth.currentHealth / (float)100, 1f, 1);
         }*/


        RectTransform rt = GetComponent<RectTransform>();
        rt.localScale = new Vector3((float)playerHealth.currentHealth / (float)100, 1f, 1);
    }
}
