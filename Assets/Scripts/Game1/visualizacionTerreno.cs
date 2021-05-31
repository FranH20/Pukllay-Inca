using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualizacionTerreno : MonoBehaviour
{
    public static visualizacionTerreno obj;
    

    private void Awake(){ //primera funcion
        obj = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("s");
    } 

    private void OnDestroy(){
        obj = null;
    }

}
