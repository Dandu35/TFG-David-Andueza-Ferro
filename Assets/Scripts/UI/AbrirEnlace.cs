using UnityEngine;

public class AbrirEnlace : MonoBehaviour
{
    // URL que quieres abrir cuando se haga clic en el botón
    public string url;

    // Método que se ejecuta cuando se hace clic en el botón
    public void AbrirEnlaceURL()
    {

        Debug.Log("Simulando apertura de enlace en el editor: " + url);

        // Abrir la URL en el navegador predeterminado
        Application.OpenURL(url);

    }
}
