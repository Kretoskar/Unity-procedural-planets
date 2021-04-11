using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter
{
    private float _roughness = 0.5f;
    private float _strength = 0.5f;
    private float _center = 0.5f;
    
    Noise noise = new Noise();

    public NoiseFilter(NoiseSettings settings)
    {
        _roughness = settings.Roughness;
        _strength = settings.Strength;
        _center = settings.Center;
    }
    
    public float Evaluate(Vector3 point)
    {
        return noise.Evaluate(point * _roughness + new Vector3(_center, _center, _center) + Vector3.one) * .5f * _strength;
    }
}
