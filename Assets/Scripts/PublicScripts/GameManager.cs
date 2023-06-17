using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    public static int Coins;
    [Header("Variables")]
    public int startCoins = 0;
    public static int Score;
    public int startScore = 0;
    public float gameOverDelay = .5f;
    public bool hasGameEnded = false;
    public GameObject PauseMenuUi;
    public AudioManager audioManager;

    [Header("Unity Scene Name")]
    public int currentLevel = 1;
    public string MainMenu = "MainMenu";

    [Header("Optional")]
    public static string playerName;
    private int levelReached;
    public int levelToUnlock;
    public string NextLevel;
    private int TotalCoins;


    void Start()
    {
        levelReached = PlayerPrefs.GetInt("levelReached", 1);
        PauseMenuUi.SetActive(false);
        Coins = startCoins;
        Score = startScore;
        playerName = PlayerPrefs.GetString("playerName", "Doodle");
        TotalCoins = PlayerPrefs.GetInt("Coins", 0);
    }

    public static void IncreaseCoins(int value, int CoinMultiplier)
    {
        Debug.Log(Coins);
        if (value > 0)
            Coins += value * CoinMultiplier;
    }

    public static void IncreaseScore()
    {
        Score++;
    }

    public void DestroyCoinBrustEffect(ParticleSystem effect)
    {
        StartCoroutine(DestroyEffect(effect));
    }

    IEnumerator DestroyEffect(ParticleSystem effect)
    {
        yield return new WaitForSeconds(1f);
        Destroy(effect);
    }

    public void EndGame(Vector3 pos)
    {
        UpdateCoins();
        audioManager.PlayLoseSfx();
        StartCoroutine(LoadTheScene());
    }

    IEnumerator LoadTheScene()
    {
        yield return new WaitForSeconds(gameOverDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelComplete()
    {
        UpdateCoins();
        audioManager.PlayOnLevelComplete();
        if (!(levelReached > levelToUnlock))
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(NextLevel);
    }

    public void PauseGame()
    {
        audioManager.PlayOnSelect();
        Time.timeScale = 0f;
        PauseMenuUi.SetActive(true);
    }

    public void ContinueGame()
    {
        audioManager.PlayOnSelect();
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        audioManager.PlayOnSelect();
        SceneManager.LoadScene(MainMenu);
    }

    void UpdateCoins()
    {
        int finalAmount = TotalCoins + Coins;
        PlayerPrefs.SetInt("Coins", finalAmount);
    }

}
