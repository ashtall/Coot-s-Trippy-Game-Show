using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseCard;
    public Transition transition;
    public GameObject BGM;

    public bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseCard.SetActive(true);
            isPaused = true;
            BGM.GetComponent<AudioSource>().Pause();
        }
        //if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        //{
        //    Time.timeScale = 1f;
        //    pauseCard.SetActive(false);
        //    isPaused = false;
        //}
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pauseCard.SetActive(false);
        BGM.GetComponent<AudioSource>().UnPause();
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        transition.TransDownTitle();
    }
}