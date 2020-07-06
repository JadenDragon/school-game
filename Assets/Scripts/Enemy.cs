using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        PATROL,
        CHASE,
        DEATH
    }

    public int enemyHealth = 60;
    public float speed = 2f;

    //store positions of enemies in scene
    [SerializeField]
    private List<Transform> positions = new List<Transform>();
    
    private int currentPosition = 0;
    private NavMeshAgent enemyAgent;
    private EnemyState current_state;
    private Transform target;

    private void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        current_state = EnemyState.PATROL;
    }

    private void Update()
    {
        switch (current_state)
        {
            case EnemyState.PATROL:
                Patrol();
                break;
            case EnemyState.CHASE:
                Chase();
                break;
            /*case EnemyState.DEATH:
                break;*/
        }

        
    }

    void Patrol()
    {
        if (currentPosition < positions.Count)
        {
            //checks if enemy position is lower than total positions in list
            //moves enemy position to next position in list
            if (Vector3.Distance(transform.position, positions[currentPosition].position) > 1f)
            {
                //moves enemy only with NavMesh in scene
                enemyAgent.destination = positions[currentPosition].position;
                Debug.Log("Just patrolling my route");
            }
            else
            {
                //move to next position
                currentPosition++;
            }
        }
        else
        {
            //reset to first position if can't go through list 
            currentPosition = 0;
        }
    }

    void Chase()
    {
        enemyAgent.destination = target.position;
        Debug.Log("Chasing Thief! ");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //chase player when in collision range
            current_state = EnemyState.CHASE;
            target = other.transform;
            StartCoroutine(Release());
        }
    }

    IEnumerator Release()
    {
        //change state to patrol after x amount of time
        yield return new WaitForSeconds(2.5f);
        current_state = EnemyState.PATROL;
    }
}
