using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {
    int currentStage = 0;
    public GameObject knife;
    public Vector3 knifePosition;

    float totalAmountKnives;
    Knife currentKnife;

    public StageManager stageManager;

    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start() {
        stageManager.ReadStage(0);
        totalAmountKnives = stageManager.knivesAmount;
        CreateKnife();
    }

    public void CreateKnife() {
        currentKnife = Instantiate(knife, knifePosition, transform.rotation).GetComponent<Knife>();
        currentKnife.HitObject += OnKnifeHitObject;
    }

    public void OnKnifeHitObject(bool target) {
        currentKnife.HitObject -= OnKnifeHitObject;
        totalAmountKnives--;
        if (target) {
            if (totalAmountKnives > 0) {
                CreateKnife();
            } else {
                currentStage++;
                stageManager.ReadStage(currentStage);
                totalAmountKnives = stageManager.knivesAmount;
                CreateKnife();
            }
        } else {
            Invoke("OpenGameOverPanel", 0.5f);
        }
    }

    public void OpenGameOverPanel() {
        gameOverPanel.SetActive(true);
    }
}
