using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ParticleSystem playEffect;
    public int value;

    void Start()
    {
        playEffect.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Doodle")
        {
            GameManager.IncreaseCoins(value);
            playEffect.Stop();
            Destroy(gameObject);
        }

    }
}
