using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnSeguimientoPlayer : MonoBehaviour
{   
    public static EnSeguimientoPlayer obj;

    Vector3 initialPosition;
    GameObject Player;
    Rigidbody2D rb;

    //
    private float movHorizontanl;

    public bool movimiento = false;

    //public GameObject Room;
    [Header("Estadistica del PlayerSeguimiento")]
    //public float vida;
   // public float vidaMax;
    public float velocidad;
    public float radioVision;
    public float radioAtaque;

    Vector3 target;


    private void Awake(){ //primera funcion
        obj = this;
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        target = initialPosition;
    }

    void Update()
    {
        MovimientoPlayer();

    }

     void MovimientoPlayer(){
        movHorizontanl = Input.GetAxisRaw("Horizontal");
        //movVertical = Input.GetAxisRaw("Vertical");
        movimiento =(movHorizontanl !=0f);

        //por defecto el enemigo volvera a su posicion inicial cuando no este en persecucion del player

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Player.transform.position - transform.position,
            radioVision,
            1 << LayerMask.NameToLayer("Player1")
            //Pone al enemigo en un layer distinto a Default para evitar el raycast
            //tambien pone al objeto ataque y al prefab slash un layer attack
            //sino los detectara como entornos y se mueve atras al hacer ataques
        );

        Vector3 forward = transform.TransformDirection(Player.transform.position - transform.position);
        Debug.DrawRay(transform.position,forward,Color.red);

        //si  el raycast encuentra el Player lo ponemos de target
        //si hay una pared en medio no lo vera
        if(hit.collider != null){
            //Debug.Log("detenido :  "+hit.collider.tag);
            if(hit.collider.tag == "Player"){
                target = Player.transform.position;
               // Debug.Log("detenido :  "+target);
            }
        }

        //Calculamos la distancia y direccion actual hasta el target
        float distancia = Vector3.Distance(target,transform.position);
        Vector3 dir = (target - transform.position).normalized;

        //si es el enemigo y esta en el rango de ataque nos paramos y le atacamos
        if(target != initialPosition && distancia < radioAtaque){
            //aqui le atacariamos pero por ahora simplemente cambiamos la animacion
            // Debug.Log("detenido1");

        }else{
            rb.MovePosition(transform.position + dir * velocidad * Time.deltaTime);
             
            //al movernos establecemos la animacion de movimiento
           // anim.speed = 1;

          // flip(movHorizontanl);//mover izquierda derecha y escala
          // anim.SetBool("Enemy1_isCaminando",true);
        }

        //una ultima comprobacion para evitar bug forzando la posicion inicial
        if(target == initialPosition && distancia < 0.02f){
            //transform.position = initialPosition;
           
            //y cambiamos la animacion de nuevo a idIn
            //anim.SetBool("Enemigo1_caminar",false);
           // anim.SetBool("Enemy1_isCaminando",false);
        }

        //El enemigo se mueve en direccion al target
//        float fixedVelocidad = velocidad * Time.deltaTime;
//        transform.position =  Vector3.MoveTowards(transform.position ,target ,fixedVelocidad);

        // debug la persecucion , creara una linea en direccion al jugador
        Debug.DrawLine(transform.position, target, Color.green);


     }



    //permirira dibujar el radio de vision sobre la scena  , dibujara una sphera
    void OnDrawGizmos(){
        Gizmos.color = Color.yellow; 
        Gizmos.DrawWireSphere(transform.position , radioVision);
        Gizmos.DrawWireSphere(transform.position , radioAtaque);
    }


   /* private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, Player.transform.position) <= range;
    }*/



    private void flip(float _xValor){
        Vector3 xscalar = transform.localScale;
        if(_xValor < 0)
            xscalar.x =Mathf.Abs(xscalar.x)*-1;
        else if(_xValor > 0)
            xscalar.x =Mathf.Abs(xscalar.x);
        
        transform.localScale =xscalar;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

    } 



    private void OnDestroy(){
        obj = null;
    }



}
