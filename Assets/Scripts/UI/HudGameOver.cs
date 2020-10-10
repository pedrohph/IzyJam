using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudGameOver : MonoBehaviour {
    [SerializeField] Text textScore = null;
    [SerializeField] Text textStage = null;

    public GameObject settingsPanel;

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home() {
        SceneManager.LoadScene(0);
    }

    public void GameOverValues(int stage, int score) {
        stage++;
        textScore.text = "" + score;
        textStage.text = "STAGE " + stage;

        
        
        if(PlayerPrefs.GetInt("HighScore", -1) < score) {
            PlayerPrefs.SetInt("HighScore", score);
        }

        if(PlayerPrefs.GetInt("HighStage", -1) < stage) {
            PlayerPrefs.SetInt("HighStage", stage);
        }
    }

    public void SettingButton() {
        settingsPanel.SetActive(true);
    }
}
