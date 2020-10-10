using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudGameOver : MonoBehaviour {
    [SerializeField] Text textScore = null;
    [SerializeField] Text textStage = null;
    
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home() {
        //Go to main menu
    }

    public void GameOverValues(int stage, int score) {
        stage++;
        textScore.text = "" + score;
        textStage.text = "STAGE " + stage;
    }
}
