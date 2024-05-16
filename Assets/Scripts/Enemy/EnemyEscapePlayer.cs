using UnityEngine;

public class EnemyEscapePlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float escapeDistance; // Distancia a la que el enemigo debe escapar del jugador
    private Transform player;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        // Si el jugador est� dentro del rango de escape
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer < escapeDistance)
        {
            SetMoving(true);

            // Calcular la direcci�n en la que el enemigo debe escapar
            Vector2 directionToPlayer = player.position - transform.position;
            Vector2 escapeDirection = -directionToPlayer.normalized;

            // Mover al enemigo en la direcci�n opuesta al jugador
            transform.Translate(escapeDirection * speed * Time.deltaTime);
        }
        else
        {
            SetMoving(false); // El enemigo no se est� moviendo
        }
    }

    void SetMoving(bool moving)
    {
        animator.SetBool("isMoving", moving); // Actualizar el par�metro isMoving en el Animator
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, escapeDistance);
    }
}
