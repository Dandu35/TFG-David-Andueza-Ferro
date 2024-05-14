using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Desafios : MonoBehaviour
{
    public GameObject objetoTexto;
    public string textoID1 = "Inserte la parte que falta del código siguiente para generar \"Hola mundo\". public class MyClass {\r\n  public static void main(String[] args) {\r\n    \r\n.\r\n.\r\n(\"Hello World\");\r\n  }\r\n}";
    public string textoID2 = "Texto para ID 2";

    void Start()
    {
        objetoTexto.GetComponent<Text>().text = textoID1;
    }

    void Update()
    {

    }
}
