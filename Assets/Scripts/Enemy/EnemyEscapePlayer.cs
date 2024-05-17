using UnityEngine;

public class EnemyEscapePlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float escapeDistance; // Distancia a la que el enemigo debe escapar del jugador
    private Transform player;
    private Animator animator;

    public float minX, maxX, minY, maxY; // Límites de movimiento aleatorio
    public float patrolSpeed = 1f;
    private Vector2 patrolDestination;
    private bool isPatrolling = true;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        SetRandomPatrolDestination();
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        // Si el jugador está dentro del rango de escape
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer < escapeDistance)
        {
            isPatrolling = false;
            SetMoving(true);

            // Calcular la dirección en la que el enemigo debe escapar
            Vector2 directionToPlayer = player.position - transform.position;
            Vector2 escapeDirection = -directionToPlayer.normalized;

            // Mover al enemigo en la dirección opuesta al jugador
            transform.Translate(escapeDirection * speed * Time.deltaTime);
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
        Gizmos.DrawWireSphere(transform.position, escapeDistance);
        Gizmos.DrawLine(new Vector2(minX, minY), new Vector2(maxX, minY));
        Gizmos.DrawLine(new Vector2(minX, minY), new Vector2(minX, maxY));
        Gizmos.DrawLine(new Vector2(minX, maxY), new Vector2(maxX, maxY));
        Gizmos.DrawLine(new Vector2(maxX, minY), new Vector2(maxX, maxY));
    }
}
