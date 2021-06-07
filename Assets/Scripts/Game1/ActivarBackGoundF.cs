using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarBackGoundF : MonoBehaviour
{
    public Transform posicionMover;
    private Vector3 PosicionInicial;
    public static bool activarMovimiento;
    public float speedMovimiento;
    private float step;

    public AudioSource clip;    
    private bool stadoMusic;
    void Start()
    {
        step = speedMovimiento * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(activarMovimiento){
            transform.position = Vector3.MoveTowards(transform.position, posicionMover.position, step);
            if(stadoMusic == false){
                stadoMusic = true;
                clip.Play();
            }

        }

        if(transform.position == posicionMover.position){
            if(stadoMusic == true){
                //stadoMusic = false;
                clip.Stop();
            }
        }



    }
}
