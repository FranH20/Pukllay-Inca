using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBaston : MonoBehaviour
{   
    public static MoverBaston obj;
    public Transform Iplayer;
    public GameObject Bara;
    public GameObject Particulas1;
    [Header("Puntos Bara")]
    public Transform [] Movimiento1Baras;
    public Transform [] Movimiento2Baras;

    public int puntoActual = 1;
    public int puntoActivarParticulas;
    public float speed;
    public bool ActivarMovimiento0;
    private bool ActivarMovimiento1;
    private bool ActivarMovimiento2;
    private bool regresarPlayer;
    private float step;
    public AudioSource clip;    
    private bool stadoMusic;

    float x;

    private void Awake(){ //primera funcion
        obj = this;
    }
    void Start()
    {
        step = speed * Time.deltaTime;
        //positionBaraPlayer=baston.transform.position;
    }

    void FixedUpdate(){
        if(ActivarMovimiento0){
            switch (puntoActual)
            {
            case 1:
                Bara.transform.position = Vector3.MoveTowards(Bara.transform.position, Movimiento1Baras[puntoActual-1].position, step);
                break;
            case 2:
                Bara.transform.position = Vector3.MoveTowards(Bara.transform.position, Movimiento1Baras[puntoActual-1].position, step);
                break;
            default:
                break;


            }
         }


         if(ActivarMovimiento1){
            switch (puntoActual)
            {
            case 1:
                Bara.transform.position = Vector3.MoveTowards(Bara.transform.position, Movimiento2Baras[puntoActual-1].position, step);
                break;
            case 2:
                Bara.transform.position = Vector3.MoveTowards(Bara.transform.position, Movimiento2Baras[puntoActual-1].position, step);
                break;
            default:
                break;


            }
            x += Time.deltaTime * 30;
            Bara.transform.rotation = Quaternion.Euler(x,0,0);
         }

         if(Bara.transform.position == Movimiento1Baras[puntoActual-1].position){
             ActivarMovimiento0=false;
             ActivarMovimiento1=true;
         }
         if(Bara.transform.position == Movimiento2Baras[puntoActual-1].position){
             //ActivarMovimiento0=false;
            if(ActivarMovimiento1){
                ActivarMovimiento1=false;
                Debug.Log("a");
                StartCoroutine(EsperarTiempoBaraSuelo());
            }

         }
         if(regresarPlayer){
            float step = speed * Time.deltaTime;
            Bara.transform.position = Vector3.MoveTowards(Bara.transform.position, Iplayer.transform.position, step);
            if(Bara.transform.position == Iplayer.transform.position){
                regresarPlayer = false;
                Bara.transform.rotation = Quaternion.Euler(0,0,45f);
                PlayerController.obj.EstadoMovimientoBara=false;
                Debug.Log("regresar a Player bara");
                
            }
         }
    }


     void Update() {
         
         
         
     }

    IEnumerator EsperarTiempoBaraSuelo()
    {
        Debug.Log("b");
        if(puntoActual == puntoActivarParticulas){
            Instantiate(Particulas1,Movimiento2Baras[puntoActual-1].position,transform.rotation);
            if(stadoMusic == false){
                stadoMusic = true;
                clip.Play();
            }
            ActivarBackGoundF.activarMovimiento = true;
        }
        //Particulas1.SetActive(true);
        yield return new WaitForSeconds(2.3f);
        //Destroy(Particulas1,1.2f);
        if(puntoActual == puntoActivarParticulas){
            ActivarBackGoundF.activarMovimiento = true;
        }
        regresarPlayer=true;
        StopCoroutine(EsperarTiempoBaraSuelo());
    }



    private void OnDestroy(){
        obj = null;
    }
}
