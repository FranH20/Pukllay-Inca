using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarScenaVideo : MonoBehaviour
{
    private bool activador;
    public int IdScena;
    void Start()
    {
        
    }
    void Update() {
        if(activador == false){
            activador=true;
            StartCoroutine(CambiarScenaGame());   
        }


    }
    IEnumerator CambiarScenaGame(){
        yield return new WaitForSeconds(96.0f);
        StopCoroutine(CambiarScenaGame());
        SceneManager.LoadScene(IdScena);
    }


}
