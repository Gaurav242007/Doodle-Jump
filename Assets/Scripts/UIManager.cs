using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text Score;
    public TMP_Text Coins;
    public TMP_Text currentLevel;
    public TMP_Text doodleName;

    void Start()
    {
        Score.text = "0";
        Coins.text = "0";
        currentLevel.text = "Level " + gameManager.currentLevel.ToString();
        doodleName.text = GameManager.playerName;
    }

    void Update()
    {
        Score.text = GameManager.Score.ToString();
        Coins.text = GameManager.Coins.ToString();
    }
}
