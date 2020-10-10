using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudGame : MonoBehaviour {
    [SerializeField] Text textScore = null;
    [SerializeField] Text textStage = null;
    [SerializeField] List<Image> knives = new List<Image>();

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void NextStage(int stage, int knivesAmount) {
        stage++;
        textStage.text = "STAGE" + stage;
        if (knives.Count > knivesAmount) {
            RemoveKnives(knivesAmount);
        } else if (knives.Count < knivesAmount) {
            AddKnives(knivesAmount);
        }
        FillKnives();
    }

    public void UpgradeScore(int score) {
        textScore.text = "" + score;
    }

    private void RemoveKnives(int totalKnives) {
        for (int i = knives.Count - 1; i >= totalKnives; i--) {
            Destroy(knives[i]);
            knives.RemoveAt(i);
        }
    }

    private void AddKnives(int totalKnives) {
        int value = totalKnives - knives.Count;
        Vector3 position = new Vector3(knives[0].transform.position.x, knives[knives.Count - 1].transform.position.y, 0);
        for (int i = 0; i<value; i++) {
            position.y += 32;
            knives.Add(Instantiate(knives[0],position, transform.rotation, knives[0].transform.parent));
        }
    }

    public void UseKnife(int amountLeft) {
        knives[amountLeft].color = Color.gray;
    }

    private void FillKnives() {
        for(int i = 0; i<knives.Count; i++) {
            knives[i].color = Color.white;
        }
    }
}
