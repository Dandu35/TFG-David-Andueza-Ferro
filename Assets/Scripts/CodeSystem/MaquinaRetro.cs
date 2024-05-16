using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MaquinaRetro : MonoBehaviour
{
    public int id;
    public GameObject lootPrefab; // Prefab del objeto que se dropear�
    public Item itemToDrop;
    private bool itemDropped = false; // Bandera que indica si el �tem ya fue dropeado
    public GameObject pcCanvas;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !itemDropped) // Verifica si el jugador entr� y el �tem no ha sido dropeado a�n
        {
            Desafios.idMaquina = id;
            Explicacion.idMaquina = id;
            AbrirEnlace.idMaquina = id;
            ChatGPTManager.idMaquina = id;

            Debug.Log("ID de la m�quina retro: " + id);
        }
    }

    public void DropItem()
    {
        Time.timeScale = 1; // Pausa el juego
        pcCanvas.SetActive(false);
        Debug.Log("entre: " + id);

        if (!itemDropped && lootPrefab != null && itemToDrop != null)
        {
            Debug.Log("entreMAs: " + id);
            // Calcula la posici�n para el �tem debajo de la m�quina retro
            Vector3 dropPosition = transform.position - new Vector3(0, 1, 0); // Ajusta el segundo par�metro seg�n sea necesario

            // Instancia el prefab del �tem y lo inicializa en la posici�n calculada
            GameObject loot = Instantiate(lootPrefab, dropPosition, Quaternion.identity);
            loot.GetComponent<Loot>().Initialize(itemToDrop);
            itemDropped = true;

        }
    }
    public static MaquinaRetro FindById(int searchId)
    {
        MaquinaRetro[] maquinas = GameObject.FindObjectsOfType<MaquinaRetro>();
        foreach (MaquinaRetro maquina in maquinas)
        {
            if (maquina.id == searchId)
            {
                return maquina;
            }
        }
        return null;
    }
}
