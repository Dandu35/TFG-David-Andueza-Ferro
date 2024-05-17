using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public InventorySlot slotCarne;
    public InventorySlot slotMadera;
    public GameObject campfireUI; // Referencia al objeto UI del cofre
    private bool isPlayerNear = false;

    private void Start()
    {
        // Asegúrate de que el cofre UI esté desactivado al inicio
        if (campfireUI != null)
        {
            campfireUI.SetActive(false);
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
            // Asegúrate de ocultar el cofre cuando el jugador se aleje
            if (campfireUI != null)
            {
                campfireUI.SetActive(false);
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
        if (campfireUI != null)
        {
            campfireUI.SetActive(!campfireUI.activeSelf);
        }
    }
}

