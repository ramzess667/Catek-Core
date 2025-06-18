using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float hearingRadius = 5f;
    public float visionRadius = 7f;
    public float visionAngle = 90f;
    public Transform player;
    public LayerMask obstacleMask;
    public LayerMask soundBlockingMask;

    private int currentPointIndex = 0;
    private bool chasing = false;
    private Rigidbody2D rb;
    private Vector2 lastDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            chasing = true;
        }
        else if (CanHearPlayer())
        {
            chasing = true;
        }
        else if (chasing)
        {
            chasing = false;
        }
    }

    void FixedUpdate()
    {
        if (chasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        Transform targetPoint = patrolPoints[currentPointIndex];
        MoveTowards(targetPoint.position, patrolSpeed);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }

    void ChasePlayer()
    {
        MoveTowards(player.position, chaseSpeed);
    }

    void MoveTowards(Vector2 target, float speed)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        rb.linearVelocity = direction * speed;

        if (direction != Vector2.zero)
        {
            lastDirection = direction;
        }
    }

    bool CanSeePlayer()
    {
        Vector2 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer > visionRadius) return false;

        float angle = Vector2.Angle(lastDirection, directionToPlayer);
        if (angle > visionAngle / 2) return false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, visionRadius, obstacleMask);
        return hit.collider != null && hit.collider.transform == player;
    }

    bool CanHearPlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift)) return false;
        if (Vector2.Distance(transform.position, player.position) > hearingRadius) return false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, hearingRadius, soundBlockingMask);
        return hit.collider == null;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}