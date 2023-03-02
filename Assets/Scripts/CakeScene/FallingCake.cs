using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class FallingCake : MonoBehaviour
{
    public bool movable;
    public GameObject cake3;
    public GameObject particle;

    private void Start()
    {
        cake3 = GameObject.Find("cake3spawn");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cake3(Clone)")
        {
            Debug.Log("heehe");
            collision.gameObject.transform.SetParent(transform.parent, false);
            collision.gameObject.transform.position = cake3.transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            GameObject particles = Instantiate(particle, collision.transform);
            Destroy(particles, .5f);
        }
    }
}