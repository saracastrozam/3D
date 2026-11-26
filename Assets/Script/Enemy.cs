using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //basic
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask playerLayer;


    //states
    public float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;


    //patroling
    public Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;


    private bool alreadyAttack;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (!playerInSightRange && !playerInAttackRange){Patroling();}

        if(playerInSightRange && !playerInAttackRange){Chasing();}

       if(playerInSightRange && playerInAttackRange){Attack();}

    }

    void Patroling()
    {
        if (!walkPointSet) { SearchPoint(); }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceWalkPosition = transform.position - walkPoint;

        if(distanceWalkPosition.magnitude < 1)
        {
            walkPointSet = false;

        }
    }


    void SearchPoint()
    {
        float randomX = Random.Range(walkPointRange, -walkPointRange);
        float randomZ = Random.Range(walkPointRange, -walkPointRange);

        walkPoint = new Vector3(randomX, transform.position.y, randomZ);

        walkPointSet = true;
    }

    void Chasing()
    {
        agent.SetDestination(player.position);
    }

    void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);


        if (!alreadyAttack)
        {
            //aqui va el codigo de ataque
            Debug.Log("Ataco");
            alreadyAttack = true;
            Invoke("ResetAttack", 5f);

        }
    }

    void ResetAttack()
    {
        alreadyAttack = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.DrawWireSphere(transform.position, attackRange);

    }
}
