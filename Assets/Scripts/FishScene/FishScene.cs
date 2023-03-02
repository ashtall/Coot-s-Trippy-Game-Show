using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FishScene : MonoBehaviour
{
    public Animator animator;
    public GameObject pause;
    public GameObject timer;
    public GameObject objectiveText;
    public GameObject endCard;
    public GameObject BGM;
    public Movement coots;

    public GameObject[] fish;
    public float minForce; // The minimum force to apply
    public float maxForce; // The maximum force to apply

    //fishtimer
    private float fTimer;

    public float fLimit;
    public bool startFish;

    private void Start()
    {
        animator.Play("FishText");
        FindObjectOfType<SoundManager>().Play("FishText");
        pause.SetActive(true);
    }

    private void Update()
    {
        if (startFish)
        {
            FishTimer();
        }

        if (coots.fishCounter == 10)
        {
            EndMiniGameWin();
        }

        if (timer.GetComponent<Timer>().displayTime <= 0)
        {
            EndMiniGameLose();
        }
    }

    public void StartMiniGame()
    {
        timer.SetActive(true);
        timer.GetComponent<Timer>().timerOn = true;
        animator.Play("TimerText");
        startFish = true;
        animator.Play("FishTextIdle");
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

    private void FishTimer()
    {
        fTimer += Time.deltaTime;
        if (fTimer >= fLimit)
        {
            fTimer = 0;
            InstantiateFish();
        }
    }

    private void InstantiateFish()
    {
        // Generate a random position to instantiate the object
        Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), -5f, 0f);

        // Instantiate the object at the random position
        GameObject instantiatedObject = Instantiate(fish[Random.Range(0, 2)], randomPosition, new Quaternion(0, 0, 180, 0));

        // Apply a random force to the object
        Rigidbody2D instantiatedObjectRigidbody = instantiatedObject.GetComponent<Rigidbody2D>();
        Vector3 randomForce = new Vector3(0f, Random.Range(minForce, maxForce), 0f);
        instantiatedObjectRigidbody.AddForce(randomForce, ForceMode2D.Impulse);
    }
}