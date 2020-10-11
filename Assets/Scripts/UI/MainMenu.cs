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
    }
}
