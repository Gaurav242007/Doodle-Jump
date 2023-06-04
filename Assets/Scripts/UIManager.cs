using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text Score;
    public TMP_Text Coins;

    void Start()
    {
        Score.text = "0";
        Coins.text = "0";
    }

    void Update()
    {
        Score.text = GameManager.Score.ToString();
        Coins.text = GameManager.Coins.ToString();
    }
}
