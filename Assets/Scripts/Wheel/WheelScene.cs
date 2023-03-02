using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class WheelScene : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueTrigger dialogueTrigger;
    public Transition transition;
    public Spinner wheel;
    private PlayerData playerData;

    public bool isText;
    public bool isWheel = true;

    public int dialogueCounter;
    private int prevDialogueCounter;

    public Animator dialogueAnimator;
    public Animator animator;

    public GameObject mash;
    public GameObject reflex;
    public GameObject drag;
    public GameObject move;

    public GameObject score;
    public GameObject statsScreen;
    public GameObject win;
    public GameObject fail;
    public GameObject pause;

    public Texture2D cursor;

    private void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Main").GetComponent<PlayerData>();
        dialogueCounter = playerData.dialogueCounter;
        prevDialogueCounter = dialogueCounter;
        dialogueTrigger.StartsDialogue();
        dialogueAnimator.Play("DialogueBox_Open");
        if (playerData.dialogueCounter >= 1)
        {
            score.GetComponent<TextMeshProUGUI>().text = "Score: " + playerData.totalScore;
        }
        pause.SetActive(true);
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        transition.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

        dialogueCounter = playerData.dialogueCounter;

        if (dialogueCounter != prevDialogueCounter)
        {
            isText = true;
            prevDialogueCounter = dialogueCounter;
        }

        if (isText)
        {
            if (dialogueManager.sentences.Count == 0 && !playerData.winOrFail)
            {
                wheel.Reset();
                isText = false;
            }
        }

        if (isWheel && wheel.isStopped)
        {
            FindObjectOfType<SoundManager>().Play("Bell");
            NextScene();
            isWheel = false;
        }

        if (playerData.winOrFail && dialogueManager.isEnd)
        {
            if (playerData.winCounter == 8)
            {
                Win();
            }
            if (playerData.dialogueCounter == 10)
            {
                Fail();
            }
        }
    }

    public void Win()
    {
        //confetti
        statsScreen.SetActive(true);
        win.gameObject.SetActive(true);
    }

    public void Fail()
    {
        statsScreen.SetActive(true);
        fail.gameObject.SetActive(true);
    }

    public void NextScene()
    {
        switch (playerData.scenesArray[playerData.sceneCounter])
        {
            case "Sort":
                drag.SetActive(true);
                break;

            case "Pet":
                drag.SetActive(true);
                break;

            case "Fish":
                move.SetActive(true);
                break;

            case "Cake":
                move.SetActive(true);
                break;

            case "Button":
                reflex.SetActive(true);
                break;

            case "Math":
                reflex.SetActive(true);
                break;

            case "Eat":
                mash.SetActive(true);
                break;

            case "Bonk":
                mash.SetActive(true);
                break;
        }
        StartCoroutine(PlayAnimation());
    }

    private IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(.1f);
        animator.Play("GameModeShow");
    }

    public void TransitionOut()
    {
        transition.TransDownMinigame(playerData.scenesArray[playerData.sceneCounter]);
    }
}