using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CodyAI : MonoBehaviour
{

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        RaycastHit hit;
        //Check for sight and attack range
        if (Physics.CapsuleCast(transform.position, player.position, 1, transform.forward, out hit, 20)){
            if (hit.collider.tag == "Player"){
                playerInSightRange = true;
            }
            else{
                playerInSightRange = false;
            }
        }
        playerInAttackRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        Debug.Log(playerInSightRange);

        //if (!playerInSightRange && !playerInAttackRange) Patroling();
        //if (playerInSightRange && !playerInAttackRange) Chasing();
        //if (playerInSightRange && playerInAttackRange) Attacking();
    }



    // public void Patroling()
    // {

    //     if (!walkPointSet) SearchWalkPoint();

    //     if (walkPointSet)
    //         agent.SetDestination(walkPoint);

    //     Vector3 distanceToWalkPoint = transform.position - walkPoint;

    //     //walkpoint reached
    //     if (distanceToWalkPoint.magnitude < 1f)
    //         walkPointSet = false;

    // }

    // private void SearchWalkPoint()
    // {
    //     //Calculate random point in range
    //     float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //     float randomX = Random.Range(-walkPointRange, walkPointRange);

    //     walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    //     if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
    //         walkPointSet = true;
    // }

    public void Chasing()
    {

        agent.SetDestination(player.position);

    }

    public void Attacking()
    {
        Debug.Log("Boo");
    }
}
