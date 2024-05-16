using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbrirEnlace : MonoBehaviour
{


    private string url;
    private string textoID1 = "https://www.w3schools.com/java/java_syntax.asp";
    private string textoID2 = "https://www.w3schools.com/java/java_output_numbers.asp";
    private string textoID3 = "https://www.w3schools.com/java/java_comments.asp";
    private string textoID4 = "https://www.w3schools.com/java/java_variables.asp";

    void Start()
    {
        // Obtener el ID de la m�quina retro almacenado en PlayerPrefs
        int idMaquina = PlayerPrefs.GetInt("IDMaquina", 0); // 0 es el valor predeterminado si no se encuentra nada
        // Asignar el texto seg�n el ID de la m�quina usando un switch
        switch (idMaquina)
        {
            case 1:
                url = textoID1;
                break;
            case 2:
                url = textoID2;
                break;
            case 3:
                url = textoID3;
                break;
            case 4:
                url = textoID4;
                break;
            default:
                break;
        }
    }

// URL que quieres abrir cuando se haga clic en el bot�n


    // M�todo que se ejecuta cuando se hace clic en el bot�n
    public void AbrirEnlaceURL()
    {
        Debug.Log("Simulando apertura de enlace en el editor: " + url);
        // Abrir la URL en el navegador predeterminado
        Application.OpenURL(url);

    }
}