using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explicacion : MonoBehaviour
{
    public GameObject objetoTexto;
    public string textoID1 = "Las llaves {}marcan el principio y el final de un bloque de código.\r\n\r\n" +
        "Systemes una clase Java incorporada que contiene miembros útiles, como out, que es la abreviatura de \"salida\". El println()método, abreviatura de \"imprimir línea\"" +
        ", se utiliza para imprimir un valor en la pantalla (o un archivo).\r\n\r\nNo te preocupes demasiado por Systemy . Solo debes saber que los necesitas juntos para imprimir cosas en la pantalla.outprintln()\r\n\r\n" +
        "También debe tener en cuenta que cada declaración de código debe terminar con un punto y coma ( ;).";
    public string textoID2 = "Texto EXPLICACION para ID 2";
    public string textoID3 = "Texto EXPLICACION  para ID 3";
    public string textoID4 = "Texto EXPLICACION  para ID 4";

    void Start()
    {
        // Obtener el ID de la máquina retro almacenado en PlayerPrefs
        int idMaquina = PlayerPrefs.GetInt("IDMaquina", 0); // 0 es el valor predeterminado si no se encuentra nada

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

    void Update()
    {

    }
}

