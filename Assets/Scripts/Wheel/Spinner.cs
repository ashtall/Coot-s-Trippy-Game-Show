using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float reducer;
    public float multiplier = 1;
    private bool round1 = false;
    public bool isStopped = false;
    public bool spin = false;
    public bool sfx = false;

    private void Update()
    {
        if (isStopped && sfx)
        {
            FindObjectOfType<SoundManager>().Stop("Wheel");
            sfx = false;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Reset();
        }
    }

    private void FixedUpdate()
    {
        if (spin)
        {
            if (multiplier > 0)
            {
                transform.Rotate(Vector3.forward, 1 * multiplier);
            }
            else
            {
                isStopped = true;
            }

            if (multiplier < 20 && !round1)
            {
                multiplier += 0.1f;
            }
            else
            {
                round1 = true;
            }

            if (round1 && multiplier > 0)
            {
                multiplier -= reducer;
            }
        }
    }

    public void Reset()
    {
        multiplier = 1;
        PlayerData playerData = FindObjectOfType<PlayerData>();
        switch (playerData.scenesArray[playerData.sceneCounter])
        {
            case "Sort":
                reducer = .2f;
                break;

            case "Pet":
                reducer = .2f;
                break;

            case "Fish":
                reducer = .35f;
                break;

            case "Cake":
                reducer = .35f;
                break;

            case "Button":
                reducer = .4f;
                break;

            case "Math":
                reducer = .4f;
                break;

            case "Eat":
                reducer = .26f;
                break;

            case "Bonk":
                reducer = .26f;
                break;
        }

        round1 = false;
        isStopped = false;
        spin = true;
        sfx = true;
        FindObjectOfType<SoundManager>().Play("Wheel");
    }
}