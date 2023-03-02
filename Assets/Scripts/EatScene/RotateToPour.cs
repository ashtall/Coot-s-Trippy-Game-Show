using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RotateToPour : MonoBehaviour
{
    public Quaternion targetRotation;
    public float rotationSpeed = .1f;
    public GameObject feedingZone;

    public GameObject bowlColliders;

    public GameObject foodSpawn;
    public GameObject[] food;
    private bool foodStart = false;
    private bool foodEnd = false;

    private DraggableObject draggableObjectScript;
    public GameObject returnPoint;
    public float returnSpeed = 1f;
    private bool toReturn = false;
    public float interpolationValue;

    public CootsEating eatingAnimationHandler;

    public GameObject dragText;

    private void Start()
    {
        draggableObjectScript = GetComponent<DraggableObject>();
    }

    private void Update()
    {
        if (foodStart && !foodEnd)
        {
            StartCoroutine(InstantiatingFood());
            foodEnd = true;
        }

        if (transform.rotation == targetRotation)
        {
            foodStart = true;
        }

        if (toReturn)
        {
            StartCoroutine(ReturnToPoint());
        }

        if (transform.position == returnPoint.transform.position && toReturn)
        {
            Debug.Log("reset");
            transform.rotation = returnPoint.transform.rotation;
            toReturn = false;
            eatingAnimationHandler.Eating();
        }

        if (draggableObjectScript.isDragging)
        {
            dragText.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("rotating");
        if (collision.gameObject == feedingZone)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed);
            bowlColliders.SetActive(true);
        }
    }

    private IEnumerator InstantiatingFood()
    {
        for (int i = 0; i <= food.Length - 1; i++)
        {
            Instantiate(food[i], foodSpawn.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(.05f);
        }
        Debug.Log("wait for empty");
        yield return new WaitForSeconds(.5f);
        toReturn = true;
    }

    private IEnumerator ReturnToPoint()
    {
        if (transform != returnPoint)
        {
            Debug.Log("reutrning");
            draggableObjectScript.isDraggable = false;
            Vector3 startingPosition = transform.position;
            Quaternion startingRotation = transform.rotation;
            Vector3 targetPosition = returnPoint.transform.position;
            targetRotation = returnPoint.transform.rotation;

            float distance = Vector3.Distance(startingPosition, targetPosition);
            interpolationValue = Mathf.Lerp(0, 1, Time.deltaTime * returnSpeed / distance);
            transform.SetPositionAndRotation(Vector3.Lerp(startingPosition, targetPosition, interpolationValue), Quaternion.Slerp(startingRotation, targetRotation, interpolationValue));
            yield return new WaitForEndOfFrame();
        }
    }
}