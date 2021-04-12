using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NoiseSettings", fileName = "NoiseSettings")]
public class NoiseSettings : ScriptableObject
{
    [SerializeField] [Range(0,10)]
    private float _roughness = 0.5f;
    [SerializeField] [Range(0,10)]
    private float _baseRoughness = 0.5f;
    [SerializeField] [Range(0,10)]
    private float _strength = 0.5f;
    [SerializeField]
    private Vector3 _center;
    [SerializeField] [Range(1, 8)] 
    private int _layersCount = 6;
    [SerializeField] [Range(0,1)] 
    private float _persistence = .5f;
    [SerializeField] [Range(0,5)]
    private float _minValue = 1;

    public float MinValue => _minValue;

    public float BaseRoughness => _baseRoughness;

    public float Roughness => _roughness;

    public float Strength => _strength;

    public Vector3 Center => _center;
    
    public float LayersCount => _layersCount;

    public float Persistence => _persistence;
}
