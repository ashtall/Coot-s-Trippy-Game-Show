using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScene : MonoBehaviour
{
    public GameObject[] states;
    public Animator animator;
    public GameObject pause;
    public GameObject timer;
    public Timer timerScript;
    public GameObject objectiveText;
    public GameObject endCard;
    public GameObject BGM;

    private void Start()
    {
        animator.Play("IntroText");
        FindObjectOfType<SoundManager>().Play("ButtonText");
        pause.SetActive(true);
    }

    private void Update()
    {
        if (timerScript.displayTime <= 0)
        {
            EndMiniGame();
        }
    }

    public void StartMiniGame()
    {
        timer.SetActive(true);
        timer.GetComponent<Timer>().timerOn = true;
        animator.Play("Timer");

        animator.Play("opening");
        DisplayTheQuestion(states[Random.Range(0, 4)]);
        objectiveText.SetActive(false);
    }

    public void Right()
    {
        endCard.SetActive(true);
        endCard.GetComponent<EndCard>().isWin = true;
        timer.SetActive(false);
        BGM.SetActive(false);
    }

    public void Wrong()
    {
        endCard.SetActive(true);
        endCard.GetComponent<EndCard>().isWin = false;
        timer.SetActive(false);
        BGM.SetActive(false);
    }

    public void EndMiniGame()
    {
        endCard.SetActive(true);
        endCard.GetComponent<EndCard>().isWin = false;
        timer.SetActive(false);
        BGM.SetActive(false);
    }

    public void DisplayTheQuestion(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}