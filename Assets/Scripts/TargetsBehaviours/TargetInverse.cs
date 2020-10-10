using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInverse : Target
{
    public float decreaseSpeed;
    float rotateVelocity = 25;

    // Update is called once per frame
    void Update()
    {
        rotateVelocity += Time.deltaTime * (decreaseSpeed/100);
        currentVelocity = Mathf.Sin(rotateVelocity) * maxRotateVelocity;
        Rotate();
    }
}
