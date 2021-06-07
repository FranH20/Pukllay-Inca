using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoSeguir : MonoBehaviour
{
    public GameObject player1;


    void Start()
    {
        
    }

    void FixedUpdate(){
        transform.position = player1.transform.position;
    }
    void Update()
    {
        
    }
}
