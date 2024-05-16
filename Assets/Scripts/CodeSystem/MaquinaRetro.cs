using UnityEngine;

public class MaquinaRetro : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Guardar el ID de la máquina en PlayerPrefs
            PlayerPrefs.SetInt("IDMaquina", id);
            PlayerPrefs.Save(); // Guardar los cambios

            Debug.Log("ID de la máquina retro: " + id);
        }
    }
}
