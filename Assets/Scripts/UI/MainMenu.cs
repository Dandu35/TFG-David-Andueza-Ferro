using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject lenguageMenuUI;
    public void Play()
    {
        mainMenuUI.SetActive(false);
        lenguageMenuUI.SetActive(true);
    }

    public void LoadOptions()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void SelectLanguage(int language)
    {
        // Cargar la escena que contiene el objeto Desafios
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);

        // Llamamos al método CambiarTodosLosTextos del script Desafios después de cargar la escena
        StartCoroutine(DelayedCall(language));
    }

    IEnumerator DelayedCall(int language)
    {
        // Esperar un frame para asegurarse de que la escena se cargue completamente
        yield return null;

        // Encontrar la escena que contiene el objeto Desafios
        Scene sampleScene = SceneManager.GetSceneByName("SampleScene");
        if (sampleScene.IsValid())
        {
            // Buscar el objeto Desafios dentro de la escena
            GameObject[] rootObjects = sampleScene.GetRootGameObjects();
            foreach (GameObject rootObject in rootObjects)
            {
                Desafios desafiosScript = rootObject.GetComponentInChildren<Desafios>(true);
                if (desafiosScript != null)
                {
                    // Llamar al método CambiarTodosLosTextos con el parámetro de lenguaje
                    desafiosScript.CambiarTodosLosTextos(language);
                }

                // Buscar el script Explicacion
                Explicacion explicacionScript = rootObject.GetComponentInChildren<Explicacion>(true);
                if (explicacionScript != null)
                {
                    // Llamar al método específico de Explicacion si es necesario
                    explicacionScript.CambiarTodosLosTextos(language);
                }

                // Buscar el script AbrirEnlace
                AbrirEnlace abrirEnlaceScript = rootObject.GetComponentInChildren<AbrirEnlace>(true);
                if (abrirEnlaceScript != null)
                {
                    // Llamar al método específico de AbrirEnlace si es necesario
                    abrirEnlaceScript.CambiarTodosLosTextos(language);
                }
            }
        }
        else
        {
            Debug.LogWarning("La escena SampleScene no se cargó correctamente.");
        }

        // Descargar la escena actual
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
}
