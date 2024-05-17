using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explicacion : MonoBehaviour
{
    public static int idMaquina;
    public GameObject objetoTexto;
    public string textoID1 = "Las llaves {}marcan el principio y el final de un bloque de c�digo.\r\n\r\n" +
        "Systemes una clase Java incorporada que contiene miembros �tiles, como out, que es la abreviatura de \"salida\". El println()m�todo, abreviatura de \"imprimir l�nea\"" +
        ", se utiliza para imprimir un valor en la pantalla (o un archivo).\r\n\r\nNo te preocupes demasiado por Systemy . Solo debes saber que los necesitas juntos para imprimir cosas en la pantalla.outprintln()\r\n\r\n" +
        "Tambi�n debe tener en cuenta que cada declaraci�n de c�digo debe terminar con un punto y coma ( ;).";
    public string textoID2 = "Texto EXPLICACION para ID 2";
    public string textoID3 = "Texto EXPLICACION  para ID 3";
    public string textoID4 = "Texto EXPLICACION  para ID 4";


    void Update()
    {
        // Asignar el texto seg�n el ID de la m�quina usando un switch
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
                // Si el ID de la m�quina no coincide con ninguno de los valores conocidos, puedes establecer un texto predeterminado o manejarlo de otra manera.
                objetoTexto.GetComponent<Text>().text = "Texto predeterminado";
                break;
        }
    }
    public void CambiarTodosLosTextos(int lenguaje)
    {
        switch (lenguaje)
        {
            case 1:
                textoID1 = "Define una clase llamada \"Main\" con un m�todo principal (main), que es el punto de entrada del programa. El m�todo \"main\" toma argumentos de l�nea de comandos, aunque no los estamos usando aqu�. La l�nea System.out.println(\"Hello World\"); imprime el mensaje. Las llaves {} delimitan los bloques de c�digo en Java. Es un ejemplo com�nmente utilizado para introducirse en la programaci�n en Java.";
                textoID2 = "La l�nea String name = \"John\"; declara una variable llamada \"name\" de tipo String y le asigna el valor \"John\". La palabra clave String indica que esta variable contendr� una cadena de caracteres.\r\n\r\nLa l�nea System.out.println(name); imprime el valor de la variable \"name\" en la consola. En este caso, imprimir� \"John\". La funci�n println() se utiliza para imprimir una l�nea de texto en la consola, y en este caso, imprime el valor de la variable \"name\".";
                textoID3 = "Se definen las variables \"length\" y \"width\" para representar la longitud y el ancho del rect�ngulo, respectivamente, con valores de 4 y 6.\r\nSe calcula el �rea del rect�ngulo multiplicando la longitud por el ancho y se guarda en la variable \"area\".\r\nSe imprimen en la consola la longitud, el ancho y el �rea del rect�ngulo, con mensajes descriptivos.";
                textoID4 = "int x: Declara una variable llamada \"x\" de tipo entero. Esto significa que \"x\" puede almacenar n�meros enteros.\r\n\r\n= 100 + 50;: Asigna a la variable \"x\" el resultado de la suma de 100 y 50. Es decir, la expresi�n 100 + 50 se eval�a primero, dando como resultado 150, y luego ese valor se asigna a la variable \"x\". Entonces, despu�s de esta l�nea, \"x\" contendr� el valor 150.";
                break;
            case 2:
                textoID1 = "Using System: Importa clases del espacio de nombres System.\r\nnamespace: Organiza el c�digo.\r\nclass: Contiene datos y m�todos.\r\nMain() m�todo: Punto de entrada del programa.\r\nConsole.WriteLine(): Imprime texto en la consola.\r\nNotas adicionales: Convenciones y pr�cticas de C#.\r\nEste resumen resume los puntos clave de las l�neas proporcionadas sobre los conceptos b�sicos de C#. Si necesitas m�s informaci�n sobre alguno de estos puntos, no dudes en preguntar.";
                textoID2 = "string name = \"John\";: Esta l�nea declara una variable llamada name de tipo string y le asigna el valor \"John\". En C#, \"John\" es una cadena de caracteres, y string es el tipo de datos que representa una secuencia de caracteres.\r\n\r\nConsole.WriteLine(name);: Utiliza el m�todo WriteLine() de la clase Console para imprimir el valor de la variable name en la consola. En este caso, imprimir� \"John\" en la consola.";
                textoID3 = "int x: Declara una variable llamada \"x\" de tipo entero. Esto significa que \"x\" puede almacenar n�meros enteros.\r\n\r\n= 100 + 50;: Asigna a la variable \"x\" el resultado de la suma de 100 y 50. Es decir, la expresi�n 100 + 50 se eval�a primero, dando como resultado 150, y luego ese valor se asigna a la variable \"x\". Entonces, despu�s de esta l�nea, \"x\" contendr� el valor 150.";
                textoID4 = "La declaraci�n 1 establece una variable antes de que comience el ciclo ( int i = 0).\r\n\r\nLa declaraci�n 2 define la condici�n para que se ejecute el bucle ( idebe ser menor que 5). Si la condici�n es true, el ciclo comenzar� de nuevo; si es as� false, el ciclo finalizar�.\r\n\r\nLa declaraci�n 3 aumenta un valor ( i++) cada vez que se ejecuta el bloque de c�digo en el bucle.";
                break;
            case 3:
                textoID1 = "<!DOCTYPE html>: Declara que el documento es de tipo HTML5.\r\n<html>: Marca el inicio del documento HTML.\r\n<head>: Contiene metadatos sobre el documento, como el t�tulo de la p�gina y enlaces a scripts y estilos.\r\n<title>: Define el t�tulo de la p�gina que se muestra en la pesta�a del navegador.\r\n<body>: Contiene el contenido visible de la p�gina.\r\n<h1>: Define un encabezado de nivel 1, que es el m�s importante y grande.\r\n<p>: Define un p�rrafo de texto.";
                textoID2 = "<!DOCTYPE html>: Declara que el documento sigue la especificaci�n HTML5.\r\n<html lang=\"es\">: Establece el idioma del documento como espa�ol.\r\n<head>: Contiene metadatos del documento y enlaces a archivos externos.\r\n<meta charset=\"UTF-8\">: Define la codificaci�n de caracteres como UTF-8.\r\n<title>Mi Primer Ejercicio HTML</title>: Define el t�tulo de la p�gina.\r\n<style>: Inicia la secci�n de estilos CSS internos.\r\nbody { ... }, .container { ... }, h1 { ... }, p { ... }: Establecen estilos para elementos espec�ficos.\r\n</style>: Cierra la secci�n de estilos CSS.\r\n<body>: Contiene el contenido visible de la p�gina.\r\n<div class=\"container\">: Crea un contenedor para el contenido.\r\n<h1>: Encabezado principal.\r\n<p>: P�rrafo introductorio.\r\n<ul> y <li>: Crean una lista con elementos.\r\n</div>: Cierra el contenedor.\r\n</body>: Cierra el cuerpo del documento.\r\n</html>: Cierra el documento HTML.";
                textoID3 = "La etiqueta HTML <a>define un hiperv�nculo. Tiene la siguiente sintaxis:\r\n\r\n<a href=\"url\">link text</a>\r\nEl atributo m�s importante del <a> elemento es el hrefatributo, que indica el destino del enlace.";
                textoID4 = "El id atributo especifica una identificaci�n �nica para un elemento HTML. El valor del id atributo debe ser �nico dentro del documento HTML.\r\n\r\nEl idatributo se utiliza para se�alar una declaraci�n de estilo espec�fica en una hoja de estilo. JavaScript tambi�n lo utiliza para acceder y manipular el elemento con la identificaci�n espec�fica.\r\n\r\nLa sintaxis de id es: escriba un car�cter almohadilla (#), seguido de un nombre de id. Luego, defina las propiedades CSS entre llaves {}.";
                break;
            default:
                break;
        }
    }
}

