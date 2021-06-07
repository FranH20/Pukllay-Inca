using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PiedrasController : MonoBehaviour
{
    // Start is called before the first frame update
    public static int scorePiedras;
    public GameObject piedra1;
    public GameObject piedra2;
    public GameObject piedra3;

    void Start()
    {
        scorePiedras = 0;
        piedra1.SetActive(false);
        piedra2.SetActive(false);
        piedra3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    	if(scorePiedras >= 1)
    	{
    		piedra1.SetActive(true);
    	}    
    	if(scorePiedras >= 2)
    	{
    		piedra2.SetActive(true);
    	}
    	if(scorePiedras >= 3)
    	{
    		piedra3.SetActive(true);
            EstadoJuego.obj_estadoJuego.Game1Completo=true;
            funcCambiarEscena("ScenaMancoC");

    	}
    }
    public void funcCambiarEscena(string nombreEscena){
        SceneManager.LoadScene(nombreEscena);
    }
}
