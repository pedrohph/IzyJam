using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public Text hScoreText;
    public Text hStageText;
    public Text appleText;

    public GameObject settingsPanel;
    public GameObject storePanel;

    // Start is called before the first frame update
    void Start() {
        int hScore = PlayerPrefs.GetInt("HighScore", -1);
        int hStage = PlayerPrefs.GetInt("HighStage", -1);
        if (hScore == -1) {
            hScoreText.gameObject.SetActive(false);
        }
        if(hStage == -1) {
            hStageText.gameObject.SetActive(false);
        }
        hStageText.text = "Stage: " + hStage;
        hScoreText.text = "Score: " + hScore;
        appleText.text = "x " + PlayerPrefs.GetInt("AppleCoin", 0);
        settingsPanel.GetComponent<Settings>().ResetedData += OnResetedData;
        storePanel.GetComponent<SkinShop>().SkinBought += OnSkinBought;
    }

    public void PlayButton() {
        SceneManager.LoadScene(1);
    }

    public void SettingButton() {
        settingsPanel.SetActive(true);
    }

    public void OnResetedData() {
        hScoreText.gameObject.SetActive(false);
        hStageText.gameObject.SetActive(false);
        appleText.text = "x 0";
    }

    public void OpenStore() {
        storePanel.SetActive(true);
    }

    public void OnSkinBought() {
        int coins = PlayerPrefs.GetInt("AppleCoin", 0);
        appleText.text = "x " + coins;
    }
}
