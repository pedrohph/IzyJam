using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDecelerate : Target {
    public float decreaseSpeed;
    float rotateVelocity = 0;

    // Update is called once per frame
    void Update() {
        rotateVelocity += Time.deltaTime * (decreaseSpeed / 100);
        currentVelocity = Mathf.Abs(Mathf.Sin(rotateVelocity)) * maxRotateVelocity;
        Rotate();
    }
}
