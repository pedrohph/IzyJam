using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {
    [Header("Prefabs")]
    public GameObject knife;
    public StageManager stageManager;

    [Header("Stage info")]
    [SerializeField] Vector3 knifePosition = Vector3.zero;
    int currentStage = -1;
    int totalAmountKnives;
    Knife currentKnife;


    [Header("HUDs")]
    public GameObject gameOverPanel;
    public HudGame hud;

    public int score;

    // Start is called before the first frame update
    void Start() {
        score = 0;
        currentStage = -1;
        NextStage();
    }

    private void CreateKnife() {
        currentKnife = Instantiate(knife, knifePosition, transform.rotation).GetComponent<Knife>();
        currentKnife.HitObject += OnKnifeHitObject;
    }

    public void OnKnifeHitObject(bool target) {
        currentKnife.HitObject -= OnKnifeHitObject;
        totalAmountKnives--;
        hud.UseKnife(totalAmountKnives);
        if (target) {
            score++;
            hud.UpgradeScore(score);
            if (totalAmountKnives > 0) {
                CreateKnife();
            } else {
                NextStage();
            }
        } else {
            Invoke("OpenGameOverPanel", 0.5f);
            gameOverPanel.GetComponent<HudGameOver>().GameOverValues(currentStage, score);
        }
    }

    private void OpenGameOverPanel() {
        gameOverPanel.SetActive(true);
    }

    private void NextStage() {
        currentStage++;
        stageManager.ReadStage(currentStage);
        totalAmountKnives = stageManager.knivesAmount;
        CreateKnife();

        hud.NextStage(currentStage, totalAmountKnives);

    }
}
