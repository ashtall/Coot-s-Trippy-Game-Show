using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EatScene : MonoBehaviour
{
    public Animator introAnimator;
    public DraggableObject cerealBoxScript;
    public CootsEating cootsAnimation;

    public EatTimer timer;
    public GameObject timerText;
    public GameObject dragText;
    public GameObject feedText;
    public GameObject endCard;
    public GameObject pause;

    public GameObject vivaldi;

    // Start is called before the first frame update
    private void Start()
    {
        introAnimator.Play("FeedCootsText");
        FindObjectOfType<SoundManager>().Play("Feed");
        pause.SetActive(true);
    }

    private void Update()
    {
        if (timer.displayTime <= 0)
        {
            EndMiniGame();
        }
    }

    public void StartMiniGame()
    {
        cerealBoxScript.isDraggable = true;
        cootsAnimation.Idle();
        timerText.SetActive(false);
        timer.SetTimerText();
        timer.timerOn = true;
        dragText.SetActive(true);
        vivaldi.SetActive(true);
        feedText.SetActive(false);
    }

    public void EndMiniGame()
    {
        endCard.SetActive(true);
        timer.timerText.gameObject.SetActive(false);
        vivaldi.SetActive(false);
    }

    public IEnumerator End()
    {
        yield return new WaitForSeconds(1f);
        EndMiniGame();
    }
}