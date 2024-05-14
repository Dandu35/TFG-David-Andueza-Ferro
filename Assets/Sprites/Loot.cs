using System.Collections;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private float moveSpeed;

    private Item item;

    public void Initialize(Item item) 
    { 
        this.item = item;
        sr.sprite = item.image;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            StartCoroutine(MoveAndCollect(other.transform));
        }
    }

    private IEnumerator MoveAndCollect(Transform target)
    {
        collider.enabled = false; // Desactiva el collider para evitar múltiples llamadas de OnTriggerEnter

        while (Vector2.Distance(transform.position, target.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = target.position; // Asegúrate de que el objeto se haya movido completamente al jugador

        InventoryManager.instance.AddItem(item); // Agrega el objeto al inventario

        Destroy(gameObject); // Destruye el objeto
    }
}
