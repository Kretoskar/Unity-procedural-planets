using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator
{
    private Material _material;
    
    public ColorGenerator(Material material)
    {
        _material = material;
    }
    
    public void UpdateElevation(MinMax elevationMinMax)
    {
        _material.SetVector("_elevationMinMax", new Vector4(elevationMinMax.Min, elevationMinMax.Max));
    }
}
