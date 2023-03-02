using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PetScene : MonoBehaviour
{
    public Animator animator;
    public Animator sceneAnimator;

    public GameObject timer;
    private Timer timerScript;
    public GameObject petText;
    public GameObject endCard;
    public GameObject pause;

    public CootsPet cootsPet;

    private void Start()
    {
        petText.SetActive(true);
        animator.Play("PetText");
        FindObjectOfType<SoundManager>().Play("PetText");
        timerScript = timer.GetComponent<Timer>();
        pause.SetActive(true);
    }

    private void Update()
    {
        if (cootsPet.pettingDone)
        {
            EndMiniGame();
        }
        if (timerScript.displayTime <= 0)
        {
            EndMiniGame();
        }
    }

    public void StartMiniGame()
    {
        timer.SetActive(true);
        animator.Play("PetTimer");
        cootsPet.canPet = true;
        timer.GetComponent<Timer>().timerOn = true;
        petText.SetActive(false);
    }

    public void EndMiniGame()
    {
        timerScript.timerOn = false;
        timer.SetActive(false);
        endCard.SetActive(true);
    }
}