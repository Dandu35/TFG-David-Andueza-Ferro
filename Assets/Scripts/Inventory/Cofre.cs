using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    public GameObject cofreUI; // Referencia al objeto UI del cofre
    private bool isPlayerNear = false;

    private void Start()
    {
        // Aseg�rate de que el cofre UI est� desactivado al inicio
        if (cofreUI != null)
        {
            cofreUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            // Aseg�rate de ocultar el cofre cuando el jugador se aleje
            if (cofreUI != null)
            {
                cofreUI.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ToggleCofre();
        }
    }

    void ToggleCofre()
    {
        // Alternar la visibilidad del objeto UI del cofre
        if (cofreUI != null)
        {
            cofreUI.SetActive(!cofreUI.activeSelf);
        }
    }
}
