using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CootsPet : MonoBehaviour
{
    public float happiness;
    public float happinessSpeed;
    public float maxHappiness;

    public Slider slider;

    public bool canPet = false;
    public bool pettingDone = false;

    private void Start()
    {
        slider.maxValue = maxHappiness;
    }

    private void Update()
    {
        slider.value = happiness;
        if (Mathf.FloorToInt(happiness) == maxHappiness)
        {
            pettingDone = true;
            canPet = false;
        }
    }
}