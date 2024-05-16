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
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > attackRange) {
            SetMoving(true);
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= attackRange)
        {
            SetMoving(false);
            if (Time.time >= nextAttackTime)
            {
                AttackPlayer();
                nextAttackTime = Time.time + attackCooldown; // Establecer el próximo tiempo de ataque
            }
        }
        else
        {
            SetMoving(false); // El enemigo no se está moviendo
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


    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
