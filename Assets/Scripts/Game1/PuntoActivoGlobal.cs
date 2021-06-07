using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoActivoGlobal : MonoBehaviour
{
    public static PuntoActivoGlobal obj;
    public bool dentroRango;
    public static bool dentroRango_Game;
    public static bool dentroRango_ascensor;
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
