using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public GameObject triptext;
    private PlayerData playerData;

    private void Awake()
    {
    }

    private void Start()
    {
        if (playerData.isWin)
        {
            triptext.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Wheel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}