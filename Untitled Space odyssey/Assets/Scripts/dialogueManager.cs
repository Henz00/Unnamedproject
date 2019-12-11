using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Dialogue dialogue;
    public AudioSource source;

    

    private Queue<string> sentences;
    private Queue<AudioClip> voiceLines;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        voiceLines = new Queue<AudioClip>();
        StartDialogue(dialogue);
    }

  public void StartDialogue(Dialogue dialogue)
    {
       

        nameText.text = dialogue.name;
        sentences.Clear();
        voiceLines.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach(AudioClip voiceLine in dialogue.voiceLines)
        {
            voiceLines.Enqueue(voiceLine);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Intro"))
            SceneManager.LoadScene(3);
        else if (sentences.Count == 0 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("End"))
            SceneManager.LoadScene(5);
        string sentence = sentences.Dequeue();
        source.clip = voiceLines.Dequeue();
        source.Play();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    
}

