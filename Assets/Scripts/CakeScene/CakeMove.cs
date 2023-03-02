using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeMove : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    public GameObject particle;
    public GameObject cake2;

    public bool isDone;

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.childCount == 8)
        {
            isDone = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cake2(Clone)")
        {
            collision.transform.SetParent(gameObject.transform, false);
            collision.gameObject.GetComponent<FallingCake>().movable = true;
            collision.transform.position = cake2.transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            GameObject particles = Instantiate(particle, collision.transform);
            Destroy(particles, .5f);
        }
    }
}