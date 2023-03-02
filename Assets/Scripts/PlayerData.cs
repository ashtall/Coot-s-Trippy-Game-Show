using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public string[] scenesArray;
    public int sceneCounter;
    private int prevSceneCounter;

    public int dialogueCounter;
    public int winCounter;
    public float totalScore;
    public bool gameIntro;
    public bool fail;
    public bool winOrFail;
    public bool isWin;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    private void Start()
    {
        if (gameIntro)
        {
            Debug.Log("set scenecounter");
            sceneCounter = scenesArray.Length - 1;
        }
        RandomizeScenes(scenesArray);
    }

    private void Update()
    {
        if (fail)
        {
            dialogueCounter = 10;
        }
        if (dialogueCounter == 9)
        {
            isWin = true;
        }
        if (dialogueCounter == 9 || dialogueCounter == 10)
        {
            winOrFail = true;
        }

        if (prevSceneCounter != sceneCounter)
        {
            prevSceneCounter = sceneCounter;
        }
    }

    public void ResetData()
    {
        Debug.Log("reset");
        dialogueCounter = 0;
        winCounter = 0;
        totalScore = 0;
        sceneCounter = scenesArray.Length - 1;
        winOrFail = false;
        gameIntro = true;
        fail = false;
        winOrFail = false;
        RandomizeScenes(scenesArray);
    }

    public void RandomizeScenes(string[] scenes)
    {
        int size = scenes.Length;
        for (int i = 0; i < size; i++)
        {
            string k = scenes[i];
            int r = Random.Range(i, size);
            scenes[i] = scenes[r];
            scenes[r] = k;
        }
        scenesArray = scenes;
    }
}