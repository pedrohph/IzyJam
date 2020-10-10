using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {
    public delegate void ResetAllData();
    public event ResetAllData ResetedData;

    public Text soundStatusText;

    // Start is called before the first frame update
    void Start() {
        if (AudioListener.volume == 0) {
            soundStatusText.text = "Off";
        } else {
            soundStatusText.text = "On";
        }
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public void ResetData() {
        PlayerPrefs.DeleteAll();
        if (ResetedData != null) {
            ResetedData();
        }
    }

    public void ButtonSound() {
        if (AudioListener.volume == 0) {
            AudioListener.volume = 1;
            soundStatusText.text = "On";
        } else {
            AudioListener.volume = 0;
            soundStatusText.text = "Off";
        }
    }
}
