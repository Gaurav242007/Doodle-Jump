using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject SettingsUi;
    public GameObject ShopUI;
    public AudioManager audioManager;

    public GameObject LevelsSelector;
    public string Level01 = "Level01";

    void Start()
    {
        SettingsUi.SetActive(false);
        LevelsSelector.SetActive(false);
        ShopUI.SetActive(false);
    }

    public void Play()
    {
        audioManager.PlayOnSelect();
        SceneManager.LoadScene(Level01);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void CloseSettings(bool open)
    {
        audioManager.PlayOnSelect();
        SettingsUi.SetActive(open);
    }

    public void OpenLevelSelector(bool open)
    {
        audioManager.PlayOnSelect();
        LevelsSelector.SetActive(open);
    }

    public void OpenShop(bool open)
    {
        audioManager.PlayOnSelect();
        ShopUI.SetActive(open);
    }
}
