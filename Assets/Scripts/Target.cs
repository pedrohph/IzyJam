using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public float maxRotateVelocity;
    protected float currentVelocity;

    public int amountApples;
    public GameObject apple;

    // Start is called before the first frame update
    void Start() {
        if (amountApples != 0) {
            GenerateApples();
        }

        if (Random.Range(0, 10) % 2 == 0) {
            maxRotateVelocity *= -1;
        }

        currentVelocity = maxRotateVelocity;
    }

    // Update is called once per frame
    void Update() {
        Rotate();
    }

    protected void Rotate() {
        transform.Rotate(0, 0, currentVelocity * Time.deltaTime);
    }

    public void GenerateApples() {
        int totalApplePositions = transform.GetChild(0).childCount;
        if (totalApplePositions == 0) {
            return;
        }
        int index = Random.Range(0, totalApplePositions);
        Transform applePosition = transform.GetChild(0).GetChild(index);
        Instantiate(apple, applePosition.position, applePosition.rotation, transform);

        applePosition.parent = null;
        Destroy(applePosition.gameObject);
        amountApples--;
        if (amountApples > 0) {
            GenerateApples();
        }
    }

}
