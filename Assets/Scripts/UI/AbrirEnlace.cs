using UnityEngine;

public class AbrirEnlace : MonoBehaviour
{
    // URL que quieres abrir cuando se haga clic en el bot�n
    public string url;

    // M�todo que se ejecuta cuando se hace clic en el bot�n
    public void AbrirEnlaceURL()
    {

        Debug.Log("Simulando apertura de enlace en el editor: " + url);

        // Abrir la URL en el navegador predeterminado
        Application.OpenURL(url);

    }
}
