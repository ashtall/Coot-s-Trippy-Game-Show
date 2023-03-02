using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolumeRaise : MonoBehaviour
{
    public float speed;
    public float limit;

    public AudioSource audioSource;

    private void Update()
    {
        audioSource.volume += speed;
        if (audioSource.volume >= limit)
        {
            speed = 0.0f;
        }
    }
}