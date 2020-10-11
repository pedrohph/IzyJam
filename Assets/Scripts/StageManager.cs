using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {
    GameObject currentTarget;
    public int knivesAmount { get; private set; }
    public GameObject apple;

    public void ReadStage(int currentStage) {
        if (currentTarget != null) {
            Destroy(currentTarget);
        }

        Stage stage = Resources.Load<Stage>("Stage" + currentStage);
        if (stage != null) {
            knivesAmount = stage.AmountKnives;

            currentTarget = Instantiate(stage.target, new Vector3(0, 2.5f, 0), transform.rotation);
            if (stage.targetType == Stage.TargetType.Simple) {
                currentTarget.AddComponent<Target>();
            } else if (stage.targetType == Stage.TargetType.Inverse) {
                currentTarget.AddComponent<TargetInverse>();
                currentTarget.GetComponent<TargetInverse>().decreaseSpeed = stage.decreaseSpeed;
            } else {
                currentTarget.AddComponent<TargetDecelerate>();
                currentTarget.GetComponent<TargetDecelerate>().decreaseSpeed = stage.decreaseSpeed;
            }
            currentTarget.GetComponent<Target>().amountApples = Random.Range(0, stage.appleAmount + 1);


            currentTarget.GetComponent<Target>().apple = apple;
            currentTarget.GetComponent<Target>().maxRotateVelocity = stage.targetVelocity;
        } else {
            //Fim de jogo
        }
    }
}
