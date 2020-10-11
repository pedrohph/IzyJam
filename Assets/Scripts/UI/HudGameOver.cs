using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudGameOver : MonoBehaviour {
    public delegate void Continued();
    public event Continued ContinuedGame;
    
    [Header("Components")]
    [SerializeField] Text textScore = null;
    [SerializeField] Text textStage = null;
    [SerializeField] Text textApple = null;
    [SerializeField] Button buttonContinue = null;

    [Header("Panels")]
    public GameObject settingsPanel;
    public GameObject storePanel;

    bool usedContinue = false;

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home() {
        SceneManager.LoadScene(0);
    }

    public void GameOverValues(int stage, int score) {
        int coins = PlayerPrefs.GetInt("AppleCoin", 0);
        stage++;
        textStage.text = "STAGE " + stage;
        textScore.text = "" + score;
        textApple.text = "x " + coins;

        if (PlayerPrefs.GetInt("HighScore", -1) < score) {
            PlayerPrefs.SetInt("HighScore", score);
        }

        if (PlayerPrefs.GetInt("HighStage", -1) < stage) {
            PlayerPrefs.SetInt("HighStage", stage);
        }

        if(stage % 5 == 0) {
            stage = stage / 5;
            textStage.text = "BOSS: " + stage;
        }


        if (usedContinue) {
            buttonContinue.gameObject.SetActive(false);
        } else {
            if (coins < 50) {
                buttonContinue.interactable = false;
            } else {
                buttonContinue.interactable = true;
            }
        }
        storePanel.GetComponent<SkinShop>().SkinBought += OnSkinBought;
    }

    public void SettingButton() {
        settingsPanel.SetActive(true);
    }

    public void ContinueButton() {
        int coins = PlayerPrefs.GetInt("AppleCoin", 0);
        coins -= 50;
        PlayerPrefs.SetInt("AppleCoin", coins);
        textApple.text = "x " + coins;
        usedContinue = true;
        if (ContinuedGame != null) {
            ContinuedGame();
        }
        gameObject.SetActive(false);
    }

    public void OpenStore() {
        storePanel.SetActive(true);
    }

    public void OnSkinBought() {
        int coins = PlayerPrefs.GetInt("AppleCoin", 0);
        textApple.text = "x " + coins;
    }
}
