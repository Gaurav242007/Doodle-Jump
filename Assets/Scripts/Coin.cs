using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameManager gameManager;
    public ParticleSystem playEffect;
    public ParticleSystem brustEffect;
    public int value;

    void Start()
    {
        playEffect.Play();
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Doodle")
        {
            FindObjectOfType<AudioManager>().CoinPicked();
            GameManager.IncreaseCoins(value);
            ParticleSystem effect = Instantiate(brustEffect, transform.position, Quaternion.identity);
            gameManager.DestroyCoinBrustEffect(effect);
            playEffect.Stop();
            Destroy(gameObject);
        }

    }
}
