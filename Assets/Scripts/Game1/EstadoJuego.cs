using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoJuego : MonoBehaviour
{   public static EstadoJuego obj_estadoJuego;
    public Vector3 coordenadasP1;
    public Vector3 coordenadasP2;
    private bool CambioScena;
    public bool Game1Completo;
    public static bool activarNarra = true;


    void Awake(){
        if(obj_estadoJuego == null){
            obj_estadoJuego = this;
            DontDestroyOnLoad(gameObject);
        }else if(obj_estadoJuego!=this){
            Destroy(gameObject);
        }      
    }
    void Start()
    {
        PlayerController.obj.CoodenadasActivas=true;
        EnSeguimientoPlayer.obj.CoodenadasActivas = true;
        coordenadasP1 = PlayerController.obj.pj1Coordenadas;
        coordenadasP2 = EnSeguimientoPlayer.obj.pj1Coordenadas;
    }

    // Update is called once per frame
    void Update()
    {   
        if(CambioScena && PlayerController.obj!=null){
            PlayerController.obj.CambiarPosisionPlayer(coordenadasP1);
            EnSeguimientoPlayer.obj.CambiarPosisionPlayer(coordenadasP2);
            if(Game1Completo){
                ActivarPuente.obj.estadoPuente=true ;
                //ActivarNarracion.narracion = false;
                activarNarra = false;
            }
            CambioScena = false;
        }

        //actualiza las coordenas si el objeto existe actualmente
        if(PlayerController.obj !=null){
            //Debug.Log("esta");
            PlayerController.obj.CoodenadasActivas=true;
            EnSeguimientoPlayer.obj.CoodenadasActivas = true;
            coordenadasP1 = PlayerController.obj.pj1Coordenadas;
            coordenadasP2 = EnSeguimientoPlayer.obj.pj1Coordenadas;
        }else{
            CambioScena = true;
        }

        
    }

}
