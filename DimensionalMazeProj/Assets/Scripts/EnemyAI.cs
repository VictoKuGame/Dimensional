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
    private float health = GameControlManage.enemyHealth;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float timeBetweenAttacks;
    bool alreadyAttacked = false;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public Transform boom1;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            //*Patroling();
            //*enemyAnimator.UpdateAnimatorValues(idle);
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
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
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
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            enemyAnimator.UpdateAnimatorValues(attack);

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage()
    {
        health -= GameControlManage.playerStrength;
        if (health <= 0)
        {
            /*TODO: Hit Animation.*/
            DestroyEnemy();
        }
    }
    private void DestroyEnemy()
    {
        Instantiate(boom1, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Fireball1"))
        {
            TakeDamage();
        }
    }
}




































