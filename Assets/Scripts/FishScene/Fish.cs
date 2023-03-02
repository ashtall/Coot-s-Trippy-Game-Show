using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D c;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        c = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            c.enabled = true;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        Destroy(gameObject, 3f);
    }
}