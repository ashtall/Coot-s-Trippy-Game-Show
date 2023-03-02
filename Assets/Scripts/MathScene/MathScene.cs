using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathScene : MonoBehaviour
{
    public GameObject[] Questions;
    public GameObject timer;
    public Animator animator;
    public GameObject endCard;
    public GameObject BGM;
    public GameObject objectiveText;
    public GameObject pause;

    private void Start()
    {
        animator.Play("IntroText");
        FindObjectOfType<SoundManager>().Play("MathText");
        pause.SetActive(true);
    }

    private void Update()
    {
        if (!timer.GetComponent<Timer>().timerOn)
        {
            EndMiniGame();
        }
    }

    public void StartMiniGame()
    {
        timer.SetActive(true);
        timer.GetComponent<Timer>().timerOn = true;
        animator.Play("TimerText");
        objectiveText.SetActive(false);
        DisplayTheQuestion(Questions[Random.Range(0, 4)]);
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