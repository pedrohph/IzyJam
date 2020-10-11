using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public float maxRotateVelocity;
    protected float currentVelocity;

    public int amountApples;
    public int amountKnives;
    public GameObject apple;

    GameObject knife;
    GameObject particle;

    // Start is called before the first frame update
    void Start() {
        particle = transform.GetChild(transform.childCount - 1).gameObject;

        if (amountKnives != 0) {
            knife = transform.GetChild(1).gameObject;
            GenerateKnives();
        }


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

    private void GenerateApples() {
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

    private void GenerateKnives() {
        int totalApplePositions = transform.GetChild(0).childCount;
        if (totalApplePositions == 0) {
            return;
        }
        int index = Random.Range(0, totalApplePositions);
        Transform applePosition = transform.GetChild(0).GetChild(index);
        GameObject createdKnife = Instantiate(knife, applePosition.position, applePosition.rotation, transform);
        createdKnife.transform.Rotate(0, 0, 180);
        createdKnife.SetActive(true);

        applePosition.parent = null;
        Destroy(applePosition.gameObject);
        amountKnives--;
        if (amountKnives > 0) {
            GenerateKnives();
        }
    }


    public void TargetHit(Vector3 hitPosition) {
        gameObject.GetComponent<Animator>().Play("TargetHit");

        GameObject createdParticle = Instantiate(particle, hitPosition, gameObject.transform.rotation);
        createdParticle.GetComponent<ParticleSystem>().Play();
        Destroy(createdParticle, 1);
    }

}
