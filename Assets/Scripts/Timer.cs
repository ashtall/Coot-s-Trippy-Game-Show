using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float time;
    public float displayTime;
    public float realTime;
    public float timeFloat;
    public int timeInt;
    public bool timerOn = false;

    public bool displayInt;

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

    private void StartTimer()
    {
        if (time > 0)
        {
            realTime += Time.deltaTime;
            time -= Time.deltaTime;
            timeFloat = Mathf.Round(time * 100f) / 100f;
            timeInt = Mathf.FloorToInt(time);
            if (displayInt)
            {
                displayTime = timeInt;
            }
            if (!displayInt)
            {
                displayTime = timeFloat;
            }
            timerText.text = displayTime.ToString();
        }
        else
        {
            time = 0;
            realTime = 0;
            timerText.text = time.ToString();
            timerOn = false;
        }
    }
}