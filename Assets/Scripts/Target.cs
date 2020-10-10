using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public float maxRotateVelocity;
   protected float currentVelocity;

    // Start is called before the first frame update
    protected void Start() {
        currentVelocity = maxRotateVelocity;
    }

    // Update is called once per frame
    void Update() {
        Rotate();
    }

    protected void Rotate() {
        transform.Rotate(0, 0, currentVelocity * Time.deltaTime);
    }
}
