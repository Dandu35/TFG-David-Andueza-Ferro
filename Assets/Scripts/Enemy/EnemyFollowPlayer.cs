using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float attackRange;
    public int attackDamage = 10; // Daño del ataque
    public float attackCooldown = 2f; // Tiempo de espera entre ataques
    private Transform player;
    private float nextAttackTime = 0f;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
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

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
