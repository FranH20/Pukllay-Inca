using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarEscena : MonoBehaviour
{
    public string nombreEscena;
    public void funcCambiarEscena(string nombreEscena){
        SceneManager.LoadScene(nombreEscena);
    }
}
