using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameOver : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject gameOverMenuUI;
    private PlayerController playerController;
    public GameObject mainMenuUI;

    private void Start() {

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.MuerteJugador += ActivarMenu;
    }
    // Update is called once per frame
   
    private void ActivarMenu (object sender, EventArgs e)
    {
        gameOverMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void SaveGame()
    {

    }
}