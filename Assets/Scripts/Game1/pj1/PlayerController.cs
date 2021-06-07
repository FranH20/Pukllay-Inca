using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController obj;
    public GameObject pj;
    private float movHorizontanl;
    private float movVertical;

    public bool movimiento = false;
    //------------------
    //Estadisticas
    [Header("Estadistica del Jugador")]
    //public Image barraVida;
    public float vidaMax;
    public float vida;
    //public float score;
    public float velocitdad;
    public float velocitySalto;
    public bool EstadoMovimientoBara;
    private bool isCheckGround;
    public bool CoodenadasActivas;
    public Vector3 pj1Coordenadas;

    private Rigidbody2D rb;
    
    Animator anim;



    private void Awake(){ //primera funcion
        obj = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = pj.GetComponent<Animator>();
    }

    void Update()
    {
        //MovimientoPlayer();
    }


    void FixedUpdate(){
        //rb.velocity =new Vector2(movHorizontanl * velocitdad,movVertical );
        if(EstadoMovimientoBara == false){
            if(Input.GetKey("d") || Input.GetKey("right")){
            rb.velocity = new Vector2(velocitdad,rb.velocity.y);
            movimiento =true;
            MovimientoPlayer();
            anim.SetBool("EstaCorriendo",movimiento);

            }
            else if(Input.GetKey("a") || Input.GetKey("left")){
                rb.velocity = new Vector2(-velocitdad,rb.velocity.y);
                movimiento =true;
                anim.SetBool("EstaCorriendo",movimiento);
                MovimientoPlayer();
            }
            else{
                rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y);
                movimiento = false;
                anim.SetBool("EstaCorriendo",movimiento);

            }
            if(Input.GetKey("space") && isCheckGround){
                rb.velocity = new Vector2(rb.velocity.x,velocitySalto);
                anim.SetBool("EstaSaltando",isCheckGround);
            }


            //verificar bara
            if(Input.GetKey("f") && PuntoActivoGlobal.obj.dentroRango){                
                if(EstadoMovimientoBara==false){
                    EstadoMovimientoBara = true;
                    MoverBaston.obj.ActivarMovimiento0=true;  
                }
                
                
            }
            //elevar piedra ascensor
            if(Input.GetKey("r")){                
                if(Elevador.obj.activarMovimiento ==false){
                    Elevador.obj.activarMovimiento = true;
                }
                 
            }
            //minijugo 1
            if(Input.GetKey("g")){                
               funcCambiarEscena("Game");//Game
                 
            }


            //-----------------------
            if(isCheckGround == false){
                anim.SetBool("EstaSaltando",isCheckGround);
                //Debug.Log("piso");
            }

            if(CoodenadasActivas){
                pj1Coordenadas=transform.position;
            }



        }

            
    }

    public void CambiarPosisionPlayer(Vector3 newPosition){
        transform.position = newPosition;
    }

    public void funcCambiarEscena(string nombreEscena){
        SceneManager.LoadScene(nombreEscena);
    }

    void MovimientoPlayer(){
        movHorizontanl = Input.GetAxisRaw("Horizontal");
        //movVertical = Input.GetAxisRaw("Vertical");
        movimiento =(movHorizontanl !=0f);

        flip(movHorizontanl);//mover izquierda derecha y escala

            if(movimiento){
                //anim.SetBool("estaCorriendo",true);
            }else{
             // anim.SetBool("estaCorriendo",false);
            }

    }
    private void flip(float _xValor){
        Vector3 xscalar = transform.localScale;
        if(_xValor < 0)
            xscalar.x =Mathf.Abs(xscalar.x)*-1;
        else if(_xValor > 0)
            xscalar.x =Mathf.Abs(xscalar.x);
        
        transform.localScale =xscalar;

    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("suelo")){
            isCheckGround = true;  
            //Debug.Log("piso0");
        }
        //Debug.Log("piso0");
        //Debug.Log(collision );
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("suelo")){
            isCheckGround = false;  
            //Debug.Log("piso1");
        }
    }



    private void OnDestroy(){
        obj = null;
    }

}
