using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject SettingsUi;
    public string Level01 = "Level01";

    public void Play()
    {
        SceneManager.LoadScene(Level01);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        SettingsUi.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsUi.SetActive(false);
    }
}
