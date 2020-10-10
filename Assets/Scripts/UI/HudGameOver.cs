using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudGameOver : MonoBehaviour {
    public Text textScore;
    public Text textStage;
    private void OnEnable() {
        //Mudar o score
        textScore.text = "" + 0;
        //Mudar o estagio
        textStage.text = "STAGE " + 0;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home() {
        //Go to main menu
    }
}
