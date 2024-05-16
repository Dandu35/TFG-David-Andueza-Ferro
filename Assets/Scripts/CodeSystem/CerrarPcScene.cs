using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CerrarPcScene : MonoBehaviour
{
    public GameObject pcCanvas;
    public void ClosePCAndResumeGame()
    {
        Time.timeScale = 1f; // Reanuda el tiempo del juego
        pcCanvas.SetActive(false);
    }
}
