using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private bool isFlipped = false;
    public SpriteRenderer sprite;
    public GameObject particle;
    public TextMeshProUGUI counterText;

    public int fishCounter;
    private int inverseFishCounter = 10;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        counterText.text = "Catch " + inverseFishCounter + " Fish";
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        Flip();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fish")
        {
            Debug.Log("fish kill");
            GameObject particles = Instantiate(particle, collision.gameObject.transform.position, new Quaternion(-90, 0, 0, 0));
            Destroy(collision.gameObject);
            Destroy(particles, .5f);
            fishCounter++;
            inverseFishCounter--;
        }
    }

    private void Flip()
    {
        if (horizontalInput < 0 && !isFlipped)
        {
            sprite.flipX = false;
            isFlipped = true;
        }
        else if (horizontalInput > 0 && isFlipped)
        {
            sprite.flipX = true;
            isFlipped = false;
        }
    }
}