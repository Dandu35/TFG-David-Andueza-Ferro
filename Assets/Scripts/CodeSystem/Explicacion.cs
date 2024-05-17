using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explicacion : MonoBehaviour
{
    public static int idMaquina;
    public GameObject objetoTexto;
    public string textoID1 = "Las llaves {}marcan el principio y el final de un bloque de código.\r\n\r\n" +
        "Systemes una clase Java incorporada que contiene miembros útiles, como out, que es la abreviatura de \"salida\". El println()método, abreviatura de \"imprimir línea\"" +
        ", se utiliza para imprimir un valor en la pantalla (o un archivo).\r\n\r\nNo te preocupes demasiado por Systemy . Solo debes saber que los necesitas juntos para imprimir cosas en la pantalla.outprintln()\r\n\r\n" +
        "También debe tener en cuenta que cada declaración de código debe terminar con un punto y coma ( ;).";
    public string textoID2 = "Texto EXPLICACION para ID 2";
    public string textoID3 = "Texto EXPLICACION  para ID 3";
    public string textoID4 = "Texto EXPLICACION  para ID 4";


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
                textoID1 = "Define una clase llamada \"Main\" con un método principal (main), que es el punto de entrada del programa. El método \"main\" toma argumentos de línea de comandos, aunque no los estamos usando aquí. La línea System.out.println(\"Hello World\"); imprime el mensaje. Las llaves {} delimitan los bloques de código en Java. Es un ejemplo comúnmente utilizado para introducirse en la programación en Java.";
                textoID2 = "La línea String name = \"John\"; declara una variable llamada \"name\" de tipo String y le asigna el valor \"John\". La palabra clave String indica que esta variable contendrá una cadena de caracteres.\r\n\r\nLa línea System.out.println(name); imprime el valor de la variable \"name\" en la consola. En este caso, imprimirá \"John\". La función println() se utiliza para imprimir una línea de texto en la consola, y en este caso, imprime el valor de la variable \"name\".";
                textoID3 = "Se definen las variables \"length\" y \"width\" para representar la longitud y el ancho del rectángulo, respectivamente, con valores de 4 y 6.\r\nSe calcula el área del rectángulo multiplicando la longitud por el ancho y se guarda en la variable \"area\".\r\nSe imprimen en la consola la longitud, el ancho y el área del rectángulo, con mensajes descriptivos.";
                textoID4 = "int x: Declara una variable llamada \"x\" de tipo entero. Esto significa que \"x\" puede almacenar números enteros.\r\n\r\n= 100 + 50;: Asigna a la variable \"x\" el resultado de la suma de 100 y 50. Es decir, la expresión 100 + 50 se evalúa primero, dando como resultado 150, y luego ese valor se asigna a la variable \"x\". Entonces, después de esta línea, \"x\" contendrá el valor 150.";
                break;
            case 2:
                textoID1 = "Using System: Importa clases del espacio de nombres System.\r\nnamespace: Organiza el código.\r\nclass: Contiene datos y métodos.\r\nMain() método: Punto de entrada del programa.\r\nConsole.WriteLine(): Imprime texto en la consola.\r\nNotas adicionales: Convenciones y prácticas de C#.\r\nEste resumen resume los puntos clave de las líneas proporcionadas sobre los conceptos básicos de C#. Si necesitas más información sobre alguno de estos puntos, no dudes en preguntar.";
                textoID2 = "string name = \"John\";: Esta línea declara una variable llamada name de tipo string y le asigna el valor \"John\". En C#, \"John\" es una cadena de caracteres, y string es el tipo de datos que representa una secuencia de caracteres.\r\n\r\nConsole.WriteLine(name);: Utiliza el método WriteLine() de la clase Console para imprimir el valor de la variable name en la consola. En este caso, imprimirá \"John\" en la consola.";
                textoID3 = "int x: Declara una variable llamada \"x\" de tipo entero. Esto significa que \"x\" puede almacenar números enteros.\r\n\r\n= 100 + 50;: Asigna a la variable \"x\" el resultado de la suma de 100 y 50. Es decir, la expresión 100 + 50 se evalúa primero, dando como resultado 150, y luego ese valor se asigna a la variable \"x\". Entonces, después de esta línea, \"x\" contendrá el valor 150.";
                textoID4 = "La declaración 1 establece una variable antes de que comience el ciclo ( int i = 0).\r\n\r\nLa declaración 2 define la condición para que se ejecute el bucle ( idebe ser menor que 5). Si la condición es true, el ciclo comenzará de nuevo; si es así false, el ciclo finalizará.\r\n\r\nLa declaración 3 aumenta un valor ( i++) cada vez que se ejecuta el bloque de código en el bucle.";
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

