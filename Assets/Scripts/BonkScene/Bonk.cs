using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonk : MonoBehaviour
{
    public GameObject hand;
    public Slider slider;
    public Quaternion angleA;
    public Quaternion angleB;

    public int bonkCounter;
    public int maxBonk;

    public bool canBonk;
    public bool keyHeld;
    public bool isDone;

    private void Start()
    {
        slider.maxValue = maxBonk;
    }

    // Update is called once per frame
    private void Update()
    {
        //if (canBonk)
        //{
        //    if (Input.anyKey)
        //    {
        //        hand.transform.rotation = angleA;
        //        Add();
        //        keyHeld = true;
        //    }
        //    else
        //    {
        //        hand.transform.rotation = angleB;
        //        keyHeld = false;
        //    }
        //}

        if (canBonk)
        {
            if (Input.anyKeyDown)
            {
                hand.transform.rotation = angleA;
                bonkCounter++;
            }
            else
            {
                hand.transform.rotation = angleB;
            }
        }
        slider.value = bonkCounter;
        if (bonkCounter == maxBonk)
        {
            isDone = true;
        }
    }

    //private void Add()
    //{
    //    if (Input.anyKeyDown && !keyHeld)
    //    {
    //        bonkCounter++;
    //    }
    //}
}