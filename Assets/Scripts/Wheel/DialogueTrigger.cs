using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue[] dialogue;
    private PlayerData playerData;

    private bool add = true;

    private void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Main").GetComponent<PlayerData>();
    }

    private void Update()
    {
        if (dialogueManager.sentences.Count == 0 && add && dialogueManager.isStart)
        {
            add = false;
        }
    }

    public void StartsDialogue()
    {
        add = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[playerData.dialogueCounter]);
    }
}