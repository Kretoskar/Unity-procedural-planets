using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NoiseSettings", fileName = "NoiseSettings")]
public class NoiseSettings : ScriptableObject
{
    [SerializeField] [Range(0,10)]
    private float _roughness = 0.5f;
    [SerializeField] [Range(0,10)]
    private float _strength = 0.5f;
    [SerializeField] [Range(0,10)]
    private float _center = 0.5f;

    public float Roughness => _roughness;

    public float Strength => _strength;

    public float Center => _center;
}
