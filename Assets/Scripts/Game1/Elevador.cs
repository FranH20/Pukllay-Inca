using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    public static Elevador obj;
    public GameObject piedra;
    public Transform posicionMover;
    private Vector3 PosicionInicial;
    public bool activarMovimiento;
    public float speedMovimiento;
    private float step;


    public AudioSource clip;    
    private bool stadoMusic;

    private void Awake(){ //primera funcion
        obj = this;
    }
    void Start()
    {
        PosicionInicial = piedra.transform.position;
        step = speedMovimiento * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(activarMovimiento){
            piedra.transform.position = Vector3.MoveTowards(piedra.transform.position, posicionMover.position, step);
            if(stadoMusic == false){
                stadoMusic = true;
                clip.Play();
            }
            
        }

        if(piedra.transform.position == posicionMover.position){
            if(stadoMusic == true){
                stadoMusic = false;
                clip.Stop();
            }
        }


    }

    private void OnDestroy(){
        obj = null;
    }
    
}
