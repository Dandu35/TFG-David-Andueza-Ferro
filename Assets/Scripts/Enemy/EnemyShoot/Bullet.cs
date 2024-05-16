using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    public int damage; 
    Rigidbody2D bulletRB;

    private WorldTime worldTime;
    private int lastDay = 0;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");

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

        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
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
            damage += 5;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage); // Ajusta la cantidad de daño según tus necesidades
            }
            Destroy(gameObject);
        }
    }
}
