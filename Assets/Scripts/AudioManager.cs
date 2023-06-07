using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource lose;
    public AudioSource leveComplete;
    public AudioSource coinPick;
    public AudioSource Jump;

    public void PlayLoseSfx()
    {
        lose.Play();
    }

    public void PlayOnLevelComplete()
    {
        leveComplete.Play();
    }

    public void CoinPicked()
    {
        coinPick.Play();
    }

    public void PlayJump()
    {
        Jump.Play();
    }
}
