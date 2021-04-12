using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshDrawer : MonoBehaviour
{
    [SerializeField] private MeshData _meshData = null;
    [SerializeField] private List<NoiseSettings> _noiseSettings = null;
    [SerializeField] private Gradient _gradient;

    public MinMax elevationMinMax;

    private ColorGenerator _colorGenerator;
    private Mesh _mesh;
    private List<NoiseFilter> _noiseFilters;

    public void Generate()
    {
        SetupNoiseFilters();
        CalculateVertices();
        CalculateTriangles();
        
        _mesh.RecalculateBounds();
        _mesh.RecalculateNormals();

        UpdateColors();
    }

    private void SetupNoiseFilters()
    {
        _noiseFilters = new List<NoiseFilter>();
        foreach (var setting in _noiseSettings)
        {
            _noiseFilters.Add(new NoiseFilter(setting));
        }
    }
    
    private void CalculateVertices()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        _mesh.Clear();
        
        List<Vector3> vertices = _meshData.Vertices();
        
        elevationMinMax = new MinMax();
        
        List<Vector3> verticesAfterElevation = new List<Vector3>();
        float firstLayerValue = 0;

        foreach (Vector3 v in vertices)
        {
            float elevation = 0;
            
            if (_noiseFilters.Count > 0)
            {
                firstLayerValue = _noiseFilters[0].Evaluate(v);
            }

            elevation = firstLayerValue;

            for (var i = 1; i < _noiseFilters.Count; i++)
            {
                var noiseFilter = _noiseFilters[i];
                float mask = firstLayerValue;
                elevation += noiseFilter.Evaluate(v) * mask;
            }

            elevation = (1 + elevation);
            elevationMinMax.AddValue(elevation);
            verticesAfterElevation.Add(v * elevation);
        }

        _mesh.vertices = verticesAfterElevation.ToArray();
    }

    private void CalculateTriangles()
    {
        int[] triangles = _meshData.Triangles().ToArray();
        _mesh.triangles = triangles;
    }

    private void UpdateColors()
    {
        _colorGenerator = new ColorGenerator(GetComponent<MeshRenderer>(), _gradient);
        _colorGenerator.UpdateElevation(elevationMinMax);
        _colorGenerator.UpdateColors();
    }
}
