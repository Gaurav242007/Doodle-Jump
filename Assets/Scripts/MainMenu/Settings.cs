using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    public string defaultPlayerName = "Doodle";
    public string playerName;
    public TMP_InputField inputField;

    private void Start()
    {
        inputField.text = PlayerPrefs.GetString("playerName", defaultPlayerName);
        // Add a listener to the input field to detect changes
        inputField.onValueChanged.AddListener(UpdateTmpText);
    }

    private void UpdateTmpText(string newText)
    {
        playerName = newText;
    }


    public void SaveInput()
    {
        if (defaultPlayerName.Trim() != "")
        {
            FindObjectOfType<AudioManager>().PlayOnSelect();
            PlayerPrefs.SetString("playerName", playerName);
            gameObject.SetActive(false);
        }
    }
}
