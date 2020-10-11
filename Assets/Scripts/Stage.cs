using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Stage", menuName ="Stage")]
public class Stage : ScriptableObject {
    public enum TargetType{
        Simple,
        Inverse,
        Slowdown
    }

    [Header("Components")]
    public GameObject target;

    [Header("Level Design")]
    public int AmountKnives;

    public TargetType targetType;

    public float targetVelocity;
    public float decreaseSpeed;

    public int appleAmount;
    public int knivesOnTarget;

}
