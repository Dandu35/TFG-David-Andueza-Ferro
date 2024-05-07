using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public GameObject elementoCanvas; // Arrastra el elemento del canvas que quieres mostrar/ocultar aqu� desde el Inspector
    private bool mostrando = false;

    void Update()
    {
        // Detectar si se ha presionado la tecla Tabulador
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Cambiar el estado de mostrando
            mostrando = !mostrando;

            // Activar o desactivar el elemento del canvas seg�n el estado actual de 'mostrando'
            elementoCanvas.SetActive(mostrando);
        }
    }


}
