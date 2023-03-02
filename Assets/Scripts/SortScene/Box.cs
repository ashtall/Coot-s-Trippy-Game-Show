using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool isRed;
    public bool isYellow;
    public bool isBlue;

    public int skittleCount;

    public bool isDone = false;

    private void Update()
    {
        if (skittleCount == 2)
        {
            isDone = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isRed && collision.CompareTag("Red"))
        {
            StartCoroutine(DisablingSkittles(collision));
            skittleCount++;
        }
        if (isYellow && collision.CompareTag("Yellow"))
        {
            StartCoroutine(DisablingSkittles(collision));
            skittleCount++;
        }
        if (isBlue && collision.CompareTag("Blue"))
        {
            StartCoroutine(DisablingSkittles(collision));
            skittleCount++;
        }
    }

    private IEnumerator DisablingSkittles(Collider2D collision)
    {
        yield return new WaitForSeconds(.5f);
        collision.gameObject.GetComponent<DraggableObject>().isDraggable = false;
    }
}