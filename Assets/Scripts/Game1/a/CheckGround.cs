using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isCheckGround;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            isCheckGround = true;  
            Debug.Log("piso0");
        }
        //Debug.Log("piso0");
        //Debug.Log(collision );
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            isCheckGround = false;  
            Debug.Log("piso1");
        }
    }
}
