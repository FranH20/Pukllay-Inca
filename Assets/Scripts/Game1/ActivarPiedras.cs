using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPiedras : MonoBehaviour
{
    public static bool estadoPiedras =true;
    public GameObject piedr;
    void Start()
    {
        
    }
    void Update()
    {
        if(estadoPiedras == false){
            piedr.SetActive(false);
        }
    }
}
