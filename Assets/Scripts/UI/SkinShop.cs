using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinShop : MonoBehaviour {
    public delegate void BoughtSkin();
    public event BoughtSkin SkinBought;

    [Header("Components")]
    public Text textApples;
    public Image currentKnife;
    public GameObject buttonBuy;
    public Transform slots;

    string unlockedKnives;
    int currentSelected;
    int coins;

    KnifeSkin skins;
    
    void OnEnable() {

        skins = Resources.Load<KnifeSkin>("KnifeSkins");
        unlockedKnives = PlayerPrefs.GetString("UnlockedKnives", "1000000000000000");
        coins = PlayerPrefs.GetInt("AppleCoin", 0);
        textApples.text = "x " + coins;

        currentKnife.sprite = skins.spriteKnife[PlayerPrefs.GetInt("CurrentSkin", 0)];

        CheckSlots();

    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public void selectKnife(int i) {
        currentSelected = i;
        currentKnife.sprite = skins.spriteKnife[i];
        if (unlockedKnives[i] == '0') {
            currentKnife.color = Color.black;
            buttonBuy.SetActive(true);
        } else {
            currentKnife.color = Color.white;
            buttonBuy.SetActive(false);
            PlayerPrefs.SetInt("CurrentSkin", i);
        }
    }

    public void BuyKnife() {
        if (coins >= 100) {
            unlockedKnives = unlockedKnives.Remove(currentSelected, 1);
            unlockedKnives = unlockedKnives.Insert(currentSelected, "1");
            PlayerPrefs.SetString("UnlockedKnives", unlockedKnives);

            coins -= 100;
            PlayerPrefs.SetInt("AppleCoin", coins);
            textApples.text = "x " + coins;


            selectKnife(currentSelected);
            UpgradeSlot(currentSelected);

            if (SkinBought != null) {
                SkinBought();
            }
        }
    }

    private void UpgradeSlot(int selected) {
        if (unlockedKnives[selected] == '0') {
            slots.GetChild(selected).GetChild(0).gameObject.GetComponent<Image>().color = Color.black;
        } else {
            slots.GetChild(selected).GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    private void CheckSlots() {
        for (int i = 0; i < 16; i++) {
            slots.GetChild(i).GetChild(0).gameObject.GetComponent<Image>().sprite = skins.spriteKnife[i];
            UpgradeSlot(i);

        }
    }
}
