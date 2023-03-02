using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class BonkScene : MonoBehaviour
{
    public Animator animator;
    public Animator slimeAnimator;
    public Animator cootsAnimator;

    public GameObject timer;
    public GameObject mashText;
    public GameObject endCard;
    public GameObject pause;
    public GameObject calmMeter;
    public GameObject Coots;
    public GameObject BGM;

    public Bonk coots;

    private void Start()
    {
        mashText.SetActive(true);
        FindObjectOfType<SoundManager>().Play("Bonk");
        animator.Play("IntroText");
        cootsAnimator.Play("Entrance");
        slimeAnimator.Play("slime");
        pause.SetActive(true);
    }

    private void Update()
    {
        if (coots.isDone)
        {
            EndMiniGame();
        }
        if (timer.GetComponent<Timer>().displayTime <= 0)
        {
            EndMiniGame();
        }
    }

    public void StartMiniGame()
    {
        timer.SetActive(true);
        animator.Play("Timer");
        coots.canBonk = true;
        timer.GetComponent<Timer>().timerOn = true;
        mashText.SetActive(false);
        calmMeter.SetActive(true);
    }

    public void EndMiniGame()
    {
        timer.GetComponent<Timer>().timerOn = false;
        timer.SetActive(false);
        endCard.SetActive(true);
        BGM.SetActive(false);
    }
}