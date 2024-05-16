using UnityEngine;

public class MaquinaRetro : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Desafios.idMaquina = id;
            Explicacion.idMaquina = id;
            AbrirEnlace.idMaquina = id;

            Debug.Log("ID de la máquina retro: " + id);
        }
    }
}