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
        gameOverPanel.GetComponent<HudGameOver>().ContinuedGame += OnContinuedGame;
        score = 0;
        currentStage = -1;
        StartCoroutine(NextStage(0));
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
                StartCoroutine(NextStage(1));
            }
        } else {
            Invoke("OpenGameOverPanel", 0.5f);
            gameOverPanel.GetComponent<HudGameOver>().GameOverValues(currentStage, score);
        }
    }

    private void OpenGameOverPanel() {
        gameOverPanel.SetActive(true);
    }

    private IEnumerator NextStage(float time) {
        currentStage++;
        StartCoroutine(stageManager.ReadStage(currentStage, time));
        yield return new WaitForSeconds(time + 0.2f);
        totalAmountKnives = stageManager.knivesAmount;
        CreateKnife();

        hud.NextStage(currentStage, totalAmountKnives);
    }

    public void OnContinuedGame() {
        totalAmountKnives++;
        CreateKnife();
    }
}
