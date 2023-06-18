using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adding component if the object not has
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Vector2 touchStartPosition;
    private float movementSpeed = 10f;
    float movement = 0f;
    Rigidbody2D rb;
    public int androidSwapSpeed = 2;

    void Start()
    {
        if (PlayerPrefs.GetString("2XSpeed", "false") == "true")
            movementSpeed *= 1.2f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 swipeDelta = touch.position - touchStartPosition;

                if (swipeDelta.x > 0)
                {
                    movement = androidSwapSpeed * movementSpeed;
                }
                else if (swipeDelta.x < 0)
                {
                    movement = -androidSwapSpeed * movementSpeed;
                }
            }
        }
        else
        {
            movement = Input.GetAxis("Horizontal") * movementSpeed;
        }

    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

}
