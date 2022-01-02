using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    private float idle = 1f;
    private float run = 5f;
    private float attack = 9f;
    public EnemyAnimator enemyAnimator;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    //*Patroling while can't find player target .
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    //*Attacking.
    public float timeBetweenAttacks;
    bool alreadyAttacked=false;
    //*States.
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //.Check for sight and attack range.
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
            enemyAnimator.UpdateAnimatorValues(idle);
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
            enemyAnimator.UpdateAnimatorValues(run);
        }
        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();

        }
    }
    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();

        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //*Walkpoint reached.
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        //*Calculate random point in range.
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    private void ChasePlayer()
    {
        transform.LookAt(player);
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            /*Attack code here.
            .
            .
            .
            .
            */




            alreadyAttacked = true;
            enemyAnimator.UpdateAnimatorValues(attack);

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}






































