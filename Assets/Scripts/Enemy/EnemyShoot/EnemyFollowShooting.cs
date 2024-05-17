using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowShooting : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float attackRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Animator animator;
    private Transform player;

    private bool isPatrolling = true;
    public float minX, maxX, minY, maxY; // Límites de movimiento aleatorio
    public float patrolSpeed = 1f;
    private Vector2 patrolDestination;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        SetRandomPatrolDestination();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > attackRange)
        {
            isPatrolling = false;
            SetMoving(true);
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= attackRange && nextFireTime < Time.time) {
            isPatrolling = false;
            SetMoving(false);
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
        else
        {
            SetMoving(false);
            if (isPatrolling)
            {
                Patrol(); // Si está patrullando, continua patrullando
            }
        }

    }

    void SetMoving(bool moving)
    {
        animator.SetBool("isMoving", moving); // Actualizar el parámetro isMoving en el Animator
    }
    private void Patrol()
    {
        SetMoving(true);
        transform.position = Vector2.MoveTowards(transform.position, patrolDestination, patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolDestination) < 0.2f)
        {
            SetRandomPatrolDestination();
        }
    }

    private void SetRandomPatrolDestination()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        patrolDestination = new Vector2(randomX, randomY);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.DrawLine(new Vector2(minX, minY), new Vector2(maxX, minY));
        Gizmos.DrawLine(new Vector2(minX, minY), new Vector2(minX, maxY));
        Gizmos.DrawLine(new Vector2(minX, maxY), new Vector2(maxX, maxY));
        Gizmos.DrawLine(new Vector2(maxX, minY), new Vector2(maxX, maxY));
    }
}
