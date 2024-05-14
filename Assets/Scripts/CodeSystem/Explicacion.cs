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
    public string textoID2 = "Texto para ID 2";

    void Start()
    {
        objetoTexto.GetComponent<Text>().text = textoID1;
    }

    void Update()
    {

    }
}

