﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
//Rotação básica, definir em método e ajustar       
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
