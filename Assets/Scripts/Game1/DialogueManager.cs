using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Dialogo dialogo;
    Queue<string> sentences;
    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;
    string activeSentence;
    public float typingSpeed;
    AudioSource myAudio;
    public AudioClip speakSound;
    void Start()
    {
        sentences = new Queue<string>();
        //myAudio = GetComponent<AudioSource>();
    }
    void StartDialogue(){
        sentences.Clear();
        foreach(string sentence in dialogo.sentenciaList){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    void DisplayNextSentence(){
        if(sentences.Count<=0){
            displayText.text = activeSentence;
            return;
        }
        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;
        //Debug.Log(activeSentence);
        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));
    }

    IEnumerator TypeTheSentence(string sentence){
        displayText.text="";
        foreach(char letter in sentence.ToCharArray()){
            displayText.text+=letter;
            //myAudio.PlayOneShot(speakSound);
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            dialoguePanel.SetActive(true);
            if(PuntoActivoGlobal.dentroRango_Game == false){
                PuntoActivoGlobal.dentroRango_Game = true;
            }
            if(PuntoActivoGlobal.dentroRango_ascensor == false){
                PuntoActivoGlobal.dentroRango_ascensor = true;
            }

            StartDialogue();
        }
        
    }
    void OnTriggerStay2D(Collider2D collision){
        if(collision.CompareTag("Player") && displayText.text==activeSentence){
            if(Input.GetKeyDown(KeyCode.Return)){
                DisplayNextSentence();
            }
        }
        
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            dialoguePanel.SetActive(false);
            if(PuntoActivoGlobal.dentroRango_Game == true){
                PuntoActivoGlobal.dentroRango_Game = false;
            }
            if(PuntoActivoGlobal.dentroRango_ascensor == true){
                PuntoActivoGlobal.dentroRango_ascensor = false;
            }
            StopAllCoroutines();
            
        }
        
    }
    
    void Update()
    {
        
    }
}
