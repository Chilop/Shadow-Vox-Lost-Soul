using UnityEngine;

public abstract class BaseEnemyAI : MonoBehaviour
{
    [Header("General Settings")]
    public float visionRange = 10f;
    public float visionAngle = 45f;
    public float attackRange = 2f;
    public float moveSpeed = 3.5f;

    [Header("Patrol Settings")]
    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    private bool isPatrollingForward = true;

    [Header("Chase Settings")]
    public float chaseMemoryTime = 3f; // Tiempo de persecución tras perder al jugador
    private float chaseMemoryTimer = 0f;

    protected Transform player;
    protected bool isChasing = false;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        Debug.Log("Player found");
    }

    protected virtual void Update()
    {
        if (player == null) return;

        if (IsPlayerInVision())
        {
            chaseMemoryTimer = chaseMemoryTime;
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }
            else
            {
                ChasePlayer();
            }
        }
        else if (chaseMemoryTimer > 0)
        {
            chaseMemoryTimer -= Time.deltaTime;
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    protected bool IsPlayerInVision()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleToPlayer <= visionAngle / 2 && Vector3.Distance(transform.position, player.position) <= visionRange)
        {
            if (!Physics.Raycast(transform.position, directionToPlayer, visionRange))
            {
                Debug.Log("Player is in vision");
                return true;
            }
        }

        return false;
    }

    protected virtual void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPatrolIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            if (isPatrollingForward)
            {
                currentPatrolIndex++;
                if (currentPatrolIndex >= patrolPoints.Length)
                {
                    currentPatrolIndex = patrolPoints.Length - 2;
                    isPatrollingForward = false;
                }
            }
            else
            {
                currentPatrolIndex--;
                if (currentPatrolIndex < 0)
                {
                    currentPatrolIndex = 1;
                    isPatrollingForward = true;
                }
            }
        }
    }

    protected abstract void ChasePlayer();
    protected abstract void AttackPlayer();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 1f, 0f, 0.2f); // Amarillo semi-transparente

        Vector3 forward = transform.forward * visionRange;
        Vector3 startPoint = transform.position;

        Gizmos.DrawLine(startPoint, startPoint + forward);

        for (int i = 0; i <= 30; i++)
        {
            float angle = (-visionAngle / 2) + (visionAngle / 30) * i;
            Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward * visionRange;
            Gizmos.DrawLine(startPoint, startPoint + direction);
        }

        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
