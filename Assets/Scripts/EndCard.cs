using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndCard : MonoBehaviour
{
    public GameObject win;
    public GameObject fail;
    public Transition transition;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public EatTimer oldTimer;
    public Timer timer;

    public bool isOldTimer;

    public int scoreMultiplier;

    private bool isDone;
    public bool isWin = true;

    private void Start()
    {
        StartCoroutine(SwitchScene());
        WinOrLose();
    }

    public void Update()
    {
        if (oldTimer && !isDone)
        {
            if (oldTimer.displayTime > 0)
            {
                Debug.Log("clap");
                FindObjectOfType<SoundManager>().Play("Claps");
                win.SetActive(true);
                float score = oldTimer.displayTime * scoreMultiplier;
                scoreText.text = score.ToString("n0");
                timeText.text = oldTimer.displayTime.ToString();
                GameObject.FindGameObjectWithTag("Main").GetComponent<PlayerData>().totalScore += score;
                GameObject.FindGameObjectWithTag("Main").GetComponent<PlayerData>().winCounter++;
            }
            if (oldTimer.displayTime <= 0)
            {
                fail.SetActive(true);
                FindObjectOfType<SoundManager>().Play("Fail");
                GameObject.FindGameObjectWithTag("Main").GetComponent<PlayerData>().fail = true;
            }
            isDone = true;
        }
    }

    public void WinOrLose()
    {
        if (!oldTimer && !isDone)
        {
            if (timer.displayTime > 0 && isWin)
            {
                Win();
            }
            if (timer.displayTime <= 0)
            {
                Fail();
            }
            if (timer.displayTime > 0 && !isWin)
            {
                Fail();
            }
            isDone = true;
        }
    }

    public void Win()
    {
        win.SetActive(true);
        float score = timer.timeFloat * scoreMultiplier;
        scoreText.text = score.ToString("n0");
        timeText.text = (Mathf.Round(timer.realTime * 100f) / 100f).ToString();
        FindObjectOfType<SoundManager>().Play("Claps");
        GameObject.FindGameObjectWithTag("Main").GetComponent<PlayerData>().totalScore += score;
        GameObject.FindGameObjectWithTag("Main").GetComponent<PlayerData>().winCounter++;
    }

    public void Fail()
    {
        fail.SetActive(true);
        FindObjectOfType<SoundManager>().Play("Fail");
        GameObject.FindGameObjectWithTag("Main").GetComponent<PlayerData>().fail = true;
    }

    private IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(3f);
        transition.TransDownWheel();
    }
}