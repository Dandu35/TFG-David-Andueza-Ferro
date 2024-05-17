using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float attackRange;
    public int attackDamage = 5; // Daño del ataque
    public float attackCooldown = 2f; // Tiempo de espera entre ataques
    private Transform player;
    private float nextAttackTime = 0f;
    private Animator animator;

    public float minX, maxX, minY, maxY; // Límites de movimiento aleatorio
    public float patrolSpeed = 1f;
    private Vector2 patrolDestination;

    private bool isPatrolling = true;

    private WorldTime worldTime;
    private int lastDay = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();

        GameObject worldTimeObject = GameObject.FindWithTag("WorldTime");
        if (worldTimeObject != null)
        {
            worldTime = worldTimeObject.GetComponent<WorldTime>();
            worldTime.WorldTimeChanged += OnWorldTimeChanged;
        }
        else
        {
            Debug.LogError("No se encontró el objeto con el script WorldTime adjunto.");
        }
        SetRandomPatrolDestination();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > attackRange)
        {
            isPatrolling = false; // El enemigo ha detectado al jugador, ya no patrulla
            SetMoving(true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= attackRange)
        {
            isPatrolling = false; // El enemigo ha detectado al jugador, ya no patrulla
            SetMoving(false);
            if (Time.time >= nextAttackTime)
            {
                AttackPlayer();
                nextAttackTime = Time.time + attackCooldown; // Establecer el próximo tiempo de ataque
            }
        }
        else
        {
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

    void AttackPlayer()
    {
        // Aquí suponemos que el jugador tiene un script con un método TakeDamage(int amount)
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.TakeDamage(attackDamage);
        }
    }

    void OnDestroy()
    {
        if (worldTime != null)
        {
            worldTime.WorldTimeChanged -= OnWorldTimeChanged;
        }
    }

    private void OnWorldTimeChanged(object sender, System.TimeSpan newTime)
    {
        // Calcular el día actual
        int currentDay = (int)newTime.TotalDays + 1; // Sumamos 1 porque TotalDays empieza en 0

        // Verificar si ha cambiado el día
        if (currentDay != lastDay)
        {
            lastDay = currentDay;
            // Incrementar el daño del enemigo cada día en 5
            attackDamage += 5;
        }
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
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.DrawLine(new Vector2(minX, minY), new Vector2(maxX, minY));
        Gizmos.DrawLine(new Vector2(minX, minY), new Vector2(minX, maxY));
        Gizmos.DrawLine(new Vector2(minX, maxY), new Vector2(maxX, maxY));
        Gizmos.DrawLine(new Vector2(maxX, minY), new Vector2(maxX, maxY));
    }
}
