using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class truck : MonoBehaviour
{
    float timing = 0f;
    private Vector2 velocity;
    Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        velocity = new Vector2(6f, 0f);
        // Moves the GameObject using it's transform.
        rb.isKinematic = true;
        PlayerPrefs.SetInt("Ad", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
