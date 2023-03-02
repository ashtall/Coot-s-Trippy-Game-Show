using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    public Queue<string> sentences;

    public bool isEnd;
    public bool isStart = false;
    public bool isOngoing = false;
    public bool isPressed;

    public string sentence;

    public float speed;
    public PlayerData playerData;

    private void Start()
    {
        sentences = new Queue<string>();
        playerData = GameObject.FindGameObjectWithTag("Main").GetComponent<PlayerData>();
    }

    private void Update()
    {
        if (Input.anyKeyDown && isStart)
        {
            Debug.Log("next");
            DisplayNextSentence();
            isPressed = true;
        }
        //if (Input.anyKeyDown && isStart && isOngoing)
        //{
        //    DisplayFullSentence();
        //    Debug.Log("full");
        //}
    }

    public void StartDialogue(Dialogue dialogue)
    {
        playerData.dialogueCounter++;
        isEnd = false;
        isStart = true;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            isOngoing = true;
            int a = Random.Range(1, 3);
            if (a == 1)
            {
                FindObjectOfType<SoundManager>().Play("Meow");
            }
            if (a == 2)
            {
                FindObjectOfType<SoundManager>().Play("Meow2");
            }
            text.text += letter;
            yield return new WaitForSeconds(speed);
        }
        isOngoing = false;
        isPressed = false;
    }

    private void DisplayFullSentence()
    {
        StopAllCoroutines();
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        isOngoing = false;
        isPressed = false;
        text.text = sentence;
    }

    private void EndDialogue()
    {
        isEnd = true;
    }
}