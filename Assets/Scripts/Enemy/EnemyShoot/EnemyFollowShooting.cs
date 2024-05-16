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
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > attackRange)
        {
            SetMoving(true);
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= attackRange && nextFireTime < Time.time) {
            SetMoving(false);
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
