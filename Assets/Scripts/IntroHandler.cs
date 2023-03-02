using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class IntroHandler : MonoBehaviour
{
    public Volume volume;
    private LensDistortion lens;
    public float zoomSpeed;
    public GameObject transition;
    public GameObject wheelScene;
    private PlayerData playerData;

    private void Awake()
    {
        volume.profile.TryGet<LensDistortion>(out lens);
        playerData = GameObject.FindGameObjectWithTag("Main").GetComponent<PlayerData>();
        if (playerData.gameIntro)
        {
            transition.SetActive(false);
        }
        if (!playerData.gameIntro)
        {
            lens.scale.value = .89f;
        }
    }

    private void Update()
    {
        if (playerData.gameIntro)
        {
            lens.scale.value = Mathf.Lerp(lens.scale.value, 1f, Time.deltaTime * zoomSpeed);
        }
        if (lens.scale.value >= .9f)
        {
            playerData.gameIntro = false;
            transition.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            transition.SetActive(true);
        }
    }
}