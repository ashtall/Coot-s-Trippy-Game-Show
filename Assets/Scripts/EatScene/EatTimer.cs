using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EatTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI mashText;
    public Animator animator;
    public float time;
    public float displayTime;
    public bool timerOn = false;

    public EatScene eatScene;

    private void Start()
    {
        timerText.text = time.ToString();
    }

    private void Update()
    {
        if (timerOn)
        {
            StartTimer();
        }
    }

    public void SetTimerText()
    {
        timerText.gameObject.SetActive(true);
        animator.Play("Timer");
    }

    public void SetMashText()
    {
        mashText.gameObject.SetActive(true);
        animator.Play("MashText");
        FindObjectOfType<SoundManager>().Play("Mash");
    }

    private void StartTimer()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            displayTime = Mathf.Round(time * 100f) / 100f;
            timerText.text = displayTime.ToString();
        }
        else
        {
            time = 0;
            timerText.text = time.ToString();
            animator.StopPlayback();
            eatScene.EndMiniGame();
            timerOn = false;
        }
    }
}