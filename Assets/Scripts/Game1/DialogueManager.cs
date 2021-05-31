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
    void Start()
    {
        sentences = new Queue<string>();
    }
    void StartDialogue(){
        
    }

    
    void Update()
    {
        
    }
}
