using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoActivoGlobal : MonoBehaviour
{
    public static PuntoActivoGlobal obj;
    public bool dentroRango;
    private void Awake(){ //primera funcion
        obj = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy(){
        obj = null;
    }
}
