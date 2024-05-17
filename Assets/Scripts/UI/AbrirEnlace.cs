using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbrirEnlace : MonoBehaviour
{

    public static int idMaquina;
    private string url;
    private string textoID1 = "https://www.w3schools.com/java/java_syntax.asp";
    private string textoID2 = "https://www.w3schools.com/java/java_output_numbers.asp";
    private string textoID3 = "https://www.w3schools.com/java/java_comments.asp";
    private string textoID4 = "https://www.w3schools.com/java/java_variables.asp";

    void Update()
    {
        
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

// URL que quieres abrir cuando se haga clic en el botón


    // Método que se ejecuta cuando se hace clic en el botón
    public void AbrirEnlaceURL()
    {
        Debug.Log("Simulando apertura de enlace en el editor: " + url);
        // Abrir la URL en el navegador predeterminado
        Application.OpenURL(url);

    }
    public void CambiarTodosLosTextos(int lenguaje)
    {
        switch (lenguaje)
        {
            case 1:
                textoID1 = "https://www.w3schools.com/java/java_syntax.asp";
                textoID2 = "https://www.w3schools.com/java/java_variables.asp";
                textoID3 = "https://www.w3schools.com/java/java_variables.asp";
                textoID4 = "https://www.w3schools.com/java/java_operators.asp";
                break;
            case 2:
                textoID1 = "https://www.w3schools.com/cs/cs_syntax.php";
                textoID2 = "https://www.w3schools.com/cs/cs_variables.php";
                textoID3 = "https://www.w3schools.com/cs/cs_operators.php";
                textoID4 = "https://www.w3schools.com/cs/cs_for_loop.php";
                break;
            case 3:
                textoID1 = "Html texto 1";
                textoID2 = "Html texto 2";
                textoID3 = "Html texto 3";
                textoID4 = "Html texto 4";
                break;
            case 4:
                textoID1 = "Python texto 1";
                textoID2 = "Python texto 2";
                textoID3 = "Python texto 3";
                textoID4 = "Python texto 4";
                break;
            default:
                break;
        }
    }
}
