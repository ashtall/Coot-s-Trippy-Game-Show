using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortScene : MonoBehaviour
{
    public Animator animator;
    public Animator catAnimator;
    public GameObject timer;
    public GameObject objectiveText;
    public GameObject catHands;
    public GameObject pause;
    public GameObject[] skittles;

    public Box[] boxesScript;

    public GameObject[] objects;

    public GameObject endCard;

    public GameObject BGM;

    private SoundManager s;

    private void Start()
    {
        s = GameObject.FindObjectOfType<SoundManager>();
        s.Play("SortText");
        animator.Play("IntroText");
        catAnimator.Play("CatHands");
        pause.SetActive(true);
    }

    private void Update()
    {
        if (boxesScript[0].isDone && boxesScript[1].isDone && boxesScript[2].isDone)
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
        timer.GetComponent<Timer>().timerOn = true;
        animator.Play("TimerText");
        objectiveText.SetActive(false);
        catHands.SetActive(false);
        for (int i = 0; i <= 6; i++)
        {
            skittles[i].GetComponent<DraggableObject>().isDraggable = true;
        }
    }

    public void EndMiniGame()
    {
        endCard.SetActive(true);
        timer.SetActive(false);
        BGM.SetActive(false);
    }
}