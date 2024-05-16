using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Desafios : MonoBehaviour
{
    public static int idMaquina;
    public GameObject objetoTexto;
    public string textoID1 = "Inserte la parte que falta del código siguiente para generar \"Hola mundo\". public class MyClass {\r\n  public static void main(String[] args) {\r\n    \r\n.\r\n.\r\n(\"Hello World\");\r\n  }\r\n}";
    public string textoID2 = "Texto para ID 2";
    public string textoID3 = "Texto para ID 3";
    public string textoID4 = "Texto para ID 4";

    void Update()
    {
        // Asignar el texto según el ID de la máquina usando un switch
        switch (idMaquina)
        {
            case 1:
                objetoTexto.GetComponent<Text>().text = textoID1;
                break;
            case 2:
                objetoTexto.GetComponent<Text>().text = textoID2;
                break;
            case 3:
                objetoTexto.GetComponent<Text>().text = textoID3;
                break;
            case 4:
                objetoTexto.GetComponent<Text>().text = textoID4;
                break;
            default:
                // Si el ID de la máquina no coincide con ninguno de los valores conocidos, puedes establecer un texto predeterminado o manejarlo de otra manera.
                objetoTexto.GetComponent<Text>().text = "Texto predeterminado";
                break;
        }
    }
}
