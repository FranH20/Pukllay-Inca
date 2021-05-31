using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CicloDiayNoche : MonoBehaviour
{
    public Light2D sol;
    public float velocidadTiempo;
    
    void Start(){
        StartCoroutine(Solset());
    }

    IEnumerator Solset()
    {
      while(sol.intensity >=0.0f){
          sol.intensity -=velocidadTiempo;
          yield return new WaitForSeconds(0.1f);
      }
       StartCoroutine(Solrise());
       StopCoroutine(Solset());
       
    }
    IEnumerator Solrise(){
        while(sol.intensity <= 1f){
            sol.intensity +=velocidadTiempo;
            yield return new WaitForSeconds(0.1f);
      }
       StartCoroutine(Solset());
       StopCoroutine(Solrise());

    }



}
