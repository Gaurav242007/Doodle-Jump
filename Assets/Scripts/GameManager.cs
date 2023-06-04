using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    public static int Coins;
    public int startCoins = 0;
    // Variables
    public static int Score;
    public int startScore = 0;

    void Start()
    {
        Coins = startCoins;
        Score = startScore;
    }

    public static void IncreaseCoins(int value)
    {
        if (value > 0)
            Coins += value;
    }

    public static void IncreaseScore()
    {
        Score++;
    }


}
