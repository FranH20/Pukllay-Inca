using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarEscena : MonoBehaviour
{
    public void funcCambiarEscena(string nombreEscena){
        SceneManager.LoadScene(nombreEscena);
    }
}
