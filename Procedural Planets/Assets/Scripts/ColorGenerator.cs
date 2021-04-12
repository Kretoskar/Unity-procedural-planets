using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator
{
    private MeshRenderer _renderer;
    private Texture2D _texture;
    private const int _textureResolution = 50;
    private Gradient _gradient;
    
    public ColorGenerator(MeshRenderer renderer, Gradient gradient)
    {
        _gradient = gradient;
        _renderer = renderer;
        _texture = new Texture2D(_textureResolution, 1);
    }
    
    public void UpdateElevation(MinMax elevationMinMax)
    {
        _renderer.material.SetVector("_elevationMinMax", new Vector4(elevationMinMax.Min, elevationMinMax.Max));
    }

    public void UpdateColors()
    {
        Color[] colors = new Color[_textureResolution];

        for (int i = 0; i < _textureResolution; i++)
        {
            colors[i] = _gradient.Evaluate(i / (_textureResolution - 1f));
        }
        
        _texture.SetPixels(colors);
        _texture.Apply();
        _renderer.material.SetTexture("_texture", _texture);
    }
}
