using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter
{
    private NoiseSettings _settings;
    Noise noise = new Noise();

    public NoiseFilter(NoiseSettings settings)
    {
        _settings = settings;
    }
    
    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = _settings.BaseRoughness;
        float amplitude = 1;

        for (int i = 0; i < _settings.LayersCount; i++)
        {
            float v = noise.Evaluate(point * frequency + _settings.Center);
            noiseValue += (v + 1) * .5f * amplitude;
            frequency *= _settings.Roughness;
            amplitude *= _settings.Persistence;
        }

        noiseValue = Mathf.Max(0, noiseValue - _settings.MinValue);
        return noiseValue * _settings.Strength;
    }
}
