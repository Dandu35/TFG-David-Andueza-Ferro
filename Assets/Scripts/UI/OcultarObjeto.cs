using UnityEngine;
using UnityEngine.UI;

public class OcultarYMostrarObjetos : MonoBehaviour
{
    public GameObject objetoParaOcultar;
    public GameObject objetoParaMostrar;

    public void OcultarYMostrarObjetosEnCanvas()
    {
        if (objetoParaOcultar != null && objetoParaMostrar != null)
        {
            objetoParaOcultar.SetActive(false);
            objetoParaMostrar.SetActive(true);
        }
        else
        {
            Debug.LogError("No se han asignado todos los objetos necesarios en el Inspector.");
        }
    }
}
