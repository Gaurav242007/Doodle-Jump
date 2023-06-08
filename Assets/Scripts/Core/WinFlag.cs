using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlag : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        FindObjectOfType<GameManager>().LevelComplete();
        Destroy(gameObject);
    }
}
