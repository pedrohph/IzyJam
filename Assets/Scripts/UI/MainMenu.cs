using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public Text HScoreText;
    public Text HStageText;

    public GameObject settingsPanel;

    // Start is called before the first frame update
    void Start() {
        int HScore = PlayerPrefs.GetInt("HighScore", -1);
        int HStage = PlayerPrefs.GetInt("HighStage", -1);
        if (HScore == -1) {
            HScoreText.gameObject.SetActive(false);
        }
        if(HStage == -1) {
            HStageText.gameObject.SetActive(false);
        }
        HStageText.text = "Stage: " + HStage;
        HScoreText.text = "Score: " + HScore;
        settingsPanel.GetComponent<Settings>().ResetedData += OnResetedData;
    }

    public void PlayButton() {
        SceneManager.LoadScene(1);
    }

    public void SettingButton() {
        settingsPanel.SetActive(true);
    }

    public void OnResetedData() {
        HScoreText.gameObject.SetActive(false);
        HStageText.gameObject.SetActive(false);
    }
}
