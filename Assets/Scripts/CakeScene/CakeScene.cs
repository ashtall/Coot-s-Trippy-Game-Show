using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeScene : MonoBehaviour
{
    public Animator animator;
    public GameObject pause;
    public GameObject timer;
    public GameObject objectiveText;
    public GameObject endCard;
    public GameObject BGM;

    public CakeMove cake;
    public Timer timerScript;

    public GameObject cakeTwo;
    public GameObject cakeThree;

    private void Start()
    {
        animator.Play("IntroText");
        FindObjectOfType<SoundManager>().Play("StackText");
        pause.SetActive(true);
    }

    private void Update()
    {
        if (cake.isDone)
        {
            Debug.Log("win");
            EndMiniGameWin();
        }

        if (timerScript.displayTime <= 0)
        {
            Debug.Log("lose1");

            EndMiniGameLose();
        }

        if (GameObject.Find("Cake3(Clone)").transform.position.y <= -9 || GameObject.Find("Cake2(Clone)").transform.position.y <= -9)
        {
            Debug.Log("lose2");
            EndMiniGameLose();
        }
    }

    public void StartMiniGame()
    {
        timer.SetActive(true);
        timer.GetComponent<Timer>().timerOn = true;
        animator.Play("TimerText");
        InstantiateCakes();
        objectiveText.SetActive(false);
    }

    public void EndMiniGameWin()
    {
        endCard.SetActive(true);
        endCard.GetComponent<EndCard>().isWin = true;
        timer.SetActive(false);
        BGM.SetActive(false);
    }

    public void EndMiniGameLose()
    {
        endCard.SetActive(true);
        endCard.GetComponent<EndCard>().isWin = false;
        timer.SetActive(false);
        BGM.SetActive(false);
    }

    private void InstantiateCakes()
    {
        Instantiate(cakeTwo, new Vector3(Random.Range(-5.5f, 5.5f), 10f, 0f), Quaternion.identity);
        Instantiate(cakeThree, new Vector3(Random.Range(-5.5f, 5.5f), 20f, 0f), Quaternion.identity);
    }
}