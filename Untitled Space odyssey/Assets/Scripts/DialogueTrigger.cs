using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject manager;
    public void Start()
    {
       
    }
    public void triggerDialogue()
    {
        manager.GetComponent<dialogueManager>().StartDialogue(dialogue);
    }
}
