using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarNarracion : MonoBehaviour
{
    public static bool narracion;
    public AudioSource clip;    
    private bool stadoMusic;

    void Start()
    {
    }


    void Update()
    {
                if(EstadoJuego.activarNarra){
            //narracion = false;
            if(stadoMusic == false){
                stadoMusic = true;
                clip.Play();
        }
           
        }
        
    }
}
