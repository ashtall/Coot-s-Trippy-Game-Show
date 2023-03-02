using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class CootsEating : MonoBehaviour
{
    public Animator animator;
    public GameObject[] food;
    public int i = 3;
    private bool foodOver = false;
    private bool startFeeding = false;
    private bool headUp = false;
    private bool keyHeld;

    public GameObject foodParticle;

    public EatTimer timer;
    public EatScene eatScene;

    private void Update()
    {
        if (startFeeding)
        {
            if (Input.anyKeyDown && !foodOver)
            {
                Destroy(food[i - 1]);
                GameObject particle = Instantiate(foodParticle, food[i - 1].transform.position, Quaternion.identity);
                Destroy(particle, .4f);
                i--;
            }
        }

        if (i == 0 && !headUp)
        {
            Debug.Log("headup");
            HeadUp();
            headUp = true;
            foodOver = true;
        }
    }

    public void Idle()
    {
        animator.Play("Idle");
    }

    public void Eating()
    {
        animator.Play("Eating");
        timer.SetMashText();
        startFeeding = true;
        DeleteFood();
    }

    public void HeadUp()
    {
        animator.Play("HeadUp");
    }

    public void FinishEating()
    {
        animator.Play("FinishedEating");
        timer.timerOn = false;
        StartCoroutine(eatScene.End());
    }

    private void DeleteFood()
    {
        food = GameObject.FindGameObjectsWithTag("Food");
        //i = 0;
        i = food.Length;
    }
}