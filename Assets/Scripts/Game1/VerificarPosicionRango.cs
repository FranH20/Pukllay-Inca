using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificarPosicionRango : MonoBehaviour
{   
    //public static PopSystem obj;
    public bool dentroRango; 
    public int PuntoActual;
    /*private void Awake(){ //primera funcion
        obj = this;
    }*/
    void OnTriggerStay2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
       {
            dentroRango=true;
            MoverBaston.obj.puntoActual=PuntoActual;
            PuntoActivoGlobal.obj.dentroRango=dentroRango;
       }
    } 
    void OnTriggerExit2D(Collider2D collision)
    {
        dentroRango=false;
        PuntoActivoGlobal.obj.dentroRango=dentroRango;
    } 
    /*private void OnDestroy(){
        obj = null;
    }*/
}
