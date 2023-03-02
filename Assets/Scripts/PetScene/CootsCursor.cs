using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CootsCursor : MonoBehaviour
{
    public Texture2D cursorPet;
    public Texture2D cursorPoint;

    public GameObject particle;
    private GameObject currentParticle;

    public CootsPet cootsPet;

    private Vector3 curPos;
    private Vector3 lastPos;
    private Vector2 mousePos;

    public bool petCursorState;
    public bool isMoving;

    private void Start()
    {
        Cursor.SetCursor(cursorPoint, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        if (!petCursorState)
        {
            Cursor.SetCursor(cursorPoint, Vector2.zero, CursorMode.ForceSoftware);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            petCursorState = false;
            particle.SetActive(false);
        }
        curPos = Input.mousePosition;

        if (curPos == lastPos)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        lastPos = curPos;
    }

    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Cursor.SetCursor(cursorPet, Vector2.zero, CursorMode.ForceSoftware);
            if (isMoving && cootsPet.canPet)
            {
                particle.SetActive(true);
                cootsPet.happiness += cootsPet.happinessSpeed;
            }
            petCursorState = true;
        }
        else
        {
            petCursorState = false;
        }
    }
}