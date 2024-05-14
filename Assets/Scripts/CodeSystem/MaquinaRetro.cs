using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class MaquinaRetro : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a cargar
    private bool playerInRange; // Para saber si el jugador est� en el rango de colisi�n

    // M�todo Start para verificar si el script se est� ejecutando
    void Start()
    {
        Debug.Log("Script ChangeSceneOnCollision inicializado.");
    }

    // Este m�todo se llama cuando otro Collider colisiona con el Collider del objeto al que est� adjunto este script
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter llamado.");
        // Verifica si el objeto que entra en colisi�n es el jugador
        if (collision.collider.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Jugador ha entrado en contacto con MAquinaRetro");
        }
    }

    // Este m�todo se llama cuando otro Collider deja de colisionar con el Collider del objeto al que est� adjunto este script
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit llamado.");
        // Verifica si el objeto que sale de la colisi�n es el jugador
        if (collision.collider.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Jugador ha salido del contacto con MAquinaRetro");
        }
    }

    // Este m�todo se llama una vez por frame
    private void Update()
    {
        // Solo ejecuta la l�gica si el jugador est� en rango
        if (playerInRange)
        {
            Debug.Log("Jugador est� en rango, esperando la tecla E");
            // Verifica si se ha presionado la tecla E
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Tecla E presionada, cambiando de escena a: " + sceneName);
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}