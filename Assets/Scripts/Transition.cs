using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public GameObject Scene;
    public Animator animator;

    private string scenee;

    private void Awake()
    {
        TransUp();
    }

    public void TransUp()
    {
        animator.Play("SceneTransitionUp");
    }

    public void TransDownWheel()
    {
        animator.Play("SceneTransitionDownWheel");
    }

    public void TransDownTitle()
    {
        animator.Play("SceneTransitionDownTitle");
    }

    public void TransDownMinigame(string scene)
    {
        animator.Play("SceneTransitionDownMinigame");
        scenee = scene;
    }

    public IEnumerator StartScene()
    {
        yield return new WaitForSeconds(.5f);
        Scene.SetActive(true);
    }

    public void StartMiniGame()
    {
        Scene.SetActive(true);
    }

    public void BackToWheel()
    {
        SceneManager.LoadScene("Wheel");
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadGame()
    {
        switch (scenee)
        {
            case "Sort":
                SceneManager.LoadScene("Sort");
                break;

            case "Pet":
                SceneManager.LoadScene("Pet");
                break;

            case "Fish":
                SceneManager.LoadScene("Fish");
                break;

            case "Cake":
                SceneManager.LoadScene("Cake");
                break;

            case "Button":
                SceneManager.LoadScene("Button");
                break;

            case "Math":
                SceneManager.LoadScene("Math");
                break;

            case "Eat":
                SceneManager.LoadScene("Eat");
                break;

            case "Bonk":
                SceneManager.LoadScene("Bonk");
                break;
        }
        Debug.Log("scenecounter");
        FindObjectOfType<PlayerData>().sceneCounter--;
    }
}