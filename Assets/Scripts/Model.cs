using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {
    public GameObject knife;
    public Vector3 knifePosition;
    public float totalAmountKnifes;

    Knife currentKnife;
    // Start is called before the first frame update
    void Start() {
        CreateKnife();
    }

    // Update is called once per frame
    void Update() {
    }

    public void CreateKnife() {
        currentKnife = Instantiate(knife, knifePosition, transform.rotation).GetComponent<Knife>();
        currentKnife.HitObject += OnKnifeHitObject;
    }

    public void OnKnifeHitObject(bool target) {
        currentKnife.HitObject -= OnKnifeHitObject;
        totalAmountKnifes--;
        if (target) {
            if (totalAmountKnifes > 0) {
                CreateKnife();
            } else {
                Debug.Log("You win");
            }
        } else {
            Debug.Log("Game Over");
        }
    }
}
