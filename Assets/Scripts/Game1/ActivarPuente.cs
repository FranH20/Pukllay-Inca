using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPuente : MonoBehaviour
{
    public static ActivarPuente obj;
    public bool estadoPuente;
    public GameObject puen;
    
    void Awake(){
        obj = this;
    }
    void Start()
    {
    }
    void Update(){
        if(estadoPuente){
            ActivarPiedras.estadoPiedras = false;
            puen.SetActive(true);
           
        }else{
            puen.SetActive(false);
        }
    }
    private void OnDestroy(){
        obj = null;
    }

}
