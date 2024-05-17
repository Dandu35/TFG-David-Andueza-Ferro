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

    public void CambiarTodosLosTextos(int lenguaje)
    {
        switch (lenguaje)
        {
            case 1:
                textoID1 = "En Java: Intentalo tu mismo \n public class Main {\r\n  public static void main(String[] args) {\r\n    System.out.println(\"Hello World\");\r\n  }\r\n}";
                textoID2 = "En Java: Crea una variable llamada nombre de tipo String y asígnale el valor \" John \":\r\n\r\nString name = \"John\";\r\nSystem.out.println(name)";
                textoID3 = "En Java: crea tres variables de tipo entero: \"length\" (longitud), \"width\" (ancho) y \"area\" (área). Luego, calcula el área de un rectángulo multiplicando la longitud por el ancho y asigna el resultado a la variable \"area\". Finalmente, imprime las variables en la consola junto con un mensaje descriptivo.";
                textoID4 = "En Java; Declara una variable llamada \"x\" y asigna el valor de la suma de 100 y 50. En otras palabras, \"x\" contendrá el valor 150";
                break;
            case 2:
                textoID1 = "En C#: Intentalo tu mismo \n using System;\r\n\r\nnamespace HelloWorld\r\n{\r\n  class Program\r\n  {\r\n    static void Main(string[] args)\r\n    {\r\n      Console.WriteLine(\"Hello World!\");    \r\n    }\r\n  }\r\n} ";
                textoID2 = "En C#: Crea una variable llamada nombre de tipo stringy asígnale el valor \" John \" ";
                textoID3 = "En C#: Declara una variable llamada \"x\" y asigna el valor de la suma de 100 y 50. En otras palabras, \"x\" contendrá el valor 150 ";
                textoID4 = "En C#: Intentalo tu mismo: for (int i = 0; i < 5; i++) \r\n{\r\n  Console.WriteLine(i);\r\n}";
                break;
            case 3:
                textoID1 = "En Html: Intentalo tu mismo \n <!DOCTYPE html>\r\n<html>\r\n<head>\r\n<title>Page Title</title>\r\n</head>\r\n<body>\r\n\r\n<h1>This is a Heading</h1>\r\n<p>This is a paragraph.</p>\r\n\r\n</body>\r\n</html> ";
                textoID2 = "En Html: crea un encabezado, un párrafo y una lista de cosas que te gustan hacer en tu tiempo libre ";
                textoID3 = "En Html: crea un enlace (<a>) que lleva a otra página HTML llamada \"otra_pagina.html\"";
                textoID4 = "En Html: crea un <h1> con un id ";
                break;
            default:
                break;
        }
    }
}
