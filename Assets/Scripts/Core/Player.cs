using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adding component if the object not has
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private float movementSpeed = 10f;
    float movement = 0f;
    Rigidbody2D rb;

    void Start()
    {
        if (PlayerPrefs.GetString("2XSpeed", "false") == "true")
            movementSpeed *= 1.2f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;

    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

}
