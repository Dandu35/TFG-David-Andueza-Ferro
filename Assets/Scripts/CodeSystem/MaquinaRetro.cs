using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class MaquinaRetro : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a cargar
    private bool playerInRange; // Para saber si el jugador está en el rango de colisión

    // Método Start para verificar si el script se está ejecutando
    void Start()
    {
        Debug.Log("Script ChangeSceneOnCollision inicializado.");
    }

    // Este método se llama cuando otro Collider colisiona con el Collider del objeto al que está adjunto este script
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter llamado.");
        // Verifica si el objeto que entra en colisión es el jugador
        if (collision.collider.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Jugador ha entrado en contacto con MAquinaRetro");
        }
    }

    // Este método se llama cuando otro Collider deja de colisionar con el Collider del objeto al que está adjunto este script
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit llamado.");
        // Verifica si el objeto que sale de la colisión es el jugador
        if (collision.collider.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Jugador ha salido del contacto con MAquinaRetro");
        }
    }

    // Este método se llama una vez por frame
    private void Update()
    {
        // Solo ejecuta la lógica si el jugador está en rango
        if (playerInRange)
        {
            Debug.Log("Jugador está en rango, esperando la tecla E");
            // Verifica si se ha presionado la tecla E
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Tecla E presionada, cambiando de escena a: " + sceneName);
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}