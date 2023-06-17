using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class ShopItem
{
    public TMP_Text hasPurchasedText;
    public int Amount;
    // name which is gonna be stored in PlayerPrefs
    public string itemName;
    public Button purchaseBtn;

    public void Purcahase()
    {
        if (Shop.Coins < Amount)
            return;
        int finalAmount = Shop.Coins - Amount;
        Shop.Coins = finalAmount;
        hasPurchasedText.text = "Purchased";
        PlayerPrefs.SetInt("Coins", finalAmount);
        PlayerPrefs.SetString(itemName, "true");

    }

}
