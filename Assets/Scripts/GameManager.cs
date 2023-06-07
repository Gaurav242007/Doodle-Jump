using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    public static int Coins;
    public int startCoins = 0;
    // Variables
    public static int Score;
    public int startScore = 0;
    public float gameOverDelay = .5f;
    public bool hasGameEnded = false;
    public GameObject PauseMenuUi;
    public string MainMenu = "MainMenu";


    void Start()
    {
        PauseMenuUi.SetActive(false);
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
        FindObjectOfType<AudioManager>().PlayLoseSfx();
        StartCoroutine(LoadTheScene());
    }

    IEnumerator LoadTheScene()
    {
        yield return new WaitForSeconds(gameOverDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelComplete()
    {
        Debug.Log("Game Over");
        FindObjectOfType<AudioManager>().PlayOnLevelComplete();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseMenuUi.SetActive(true);
    }

    public void ContinueGame()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
