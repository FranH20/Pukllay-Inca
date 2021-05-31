using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    
    public bool ZoomActive;
    public int OrthographicSize;
    public Vector3[] Target;

    public CinemachineVirtualCamera vcam;
    public float velocidad;
    //int player1, player2;
    private void Awake ( )
    {
        //player1 = LayerMask.NameToLayer ( "Player1" );
        //player2 = LayerMask.NameToLayer ( "Player2" );
    }
    void Start()
    {
       // Cam = Camera.main;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player")   )
        //var layerMask = collision.gameObject.layer;
       //if ( layerMask ==  player1 || layerMask == player2)
       if (collision.gameObject.layer ==6  )
       {
            ZoomActive=true;
       }
    } 
    void OnTriggerExit2D(Collider2D collision)
    {
        ZoomActive=false;
    } 

   
    void LateUpdate()
    {
        if(ZoomActive){
            //Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize,3,velocidad);
             //Cam.transform.position=Vector3.Lerp(CameraZoom.tranform.position,Target[1],velocidad);
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize,OrthographicSize,velocidad);
           
        }else{
            //Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize,5,velocidad);
            //Cam.transform.position=Vector3.Lerp(CameraZoom.tranform.position,Target[0],velocidad);
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize,3,velocidad);
            ZoomActive = false;
            
        }

        
    }
}
