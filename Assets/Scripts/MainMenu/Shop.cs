using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public ShopItem[] Items;
    public TMP_Text coinText;
    public static int Coins;

    void Start()
    {
        Coins = PlayerPrefs.GetInt("Coins", 0);
        coinText.text = Coins.ToString();
        foreach (ShopItem item in Items)
        {
            HasPurcahsed(item);
        }

    }

    void HasPurcahsed(ShopItem item)
    {
        if (PlayerPrefs.GetString(item.itemName, "false") == "true")
        {
            LockPurchasedBtn(item.purchaseBtn, item.hasPurchasedText);
            return;
        }
        else if (item.Amount > Coins)
        {
            item.purchaseBtn.interactable = false;
            return;
        }
        item.purchaseBtn.onClick.AddListener(item.Purcahase);
        FindObjectOfType<AudioManager>().Purcahased();
    }

    void LockPurchasedBtn(Button btn, TMP_Text _text)
    {
        _text.text = "Purchased";
        btn.interactable = false;
    }

    void Update()
    {
        coinText.text = Coins.ToString();
    }
}
