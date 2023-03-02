using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public PlayerData playerData;

    private void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Main").GetComponent<PlayerData>();
    }

    private void Update()
    {
        scoreText.text = "Score: " + playerData.totalScore.ToString();
    }

    public void PLayAgain()
    {
        playerData.ResetData();
        playerData.dialogueCounter = 0;
        playerData.winCounter = 0;
        playerData.totalScore = 0;
        SceneManager.LoadScene("Wheel");
    }

    public void ReturnToTitle()
    {
        playerData.ResetData();
        playerData.dialogueCounter = 0;
        playerData.totalScore = 0;
        playerData.winCounter = 0;
        playerData.gameIntro = true;
        SceneManager.LoadScene("Title");
    }
}