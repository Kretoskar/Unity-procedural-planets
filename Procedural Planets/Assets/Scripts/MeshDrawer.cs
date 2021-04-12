using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshDrawer : MonoBehaviour
{
    [SerializeField] private MeshData _meshData = null;
    [SerializeField] private List<NoiseSettings> _noiseSettings = null;
    
    private Mesh _mesh;
    private List<NoiseFilter> _noiseFilters;

    private void Start()
    {
        _noiseFilters = new List<NoiseFilter>();
        foreach (var setting in _noiseSettings)
        {
            _noiseFilters.Add(new NoiseFilter(setting));
        }
        
        DateTime startTime = DateTime.UtcNow;

        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        
        _mesh.Clear();

        List<Vector3> vertices = _meshData.Vertices();
        int[] triangles = _meshData.Triangles().ToArray();
        
        
        List<Vector3> verticesAfterElevation = new List<Vector3>();
        
        foreach (Vector3 v in vertices)
        {
            float elevation = 0;
            foreach (var noiseFilter in _noiseFilters)
            {
                elevation += noiseFilter.Evaluate(v);
            }
            verticesAfterElevation.Add(v * (1 + elevation));
        }
        
        _mesh.vertices = verticesAfterElevation.ToArray();
        _mesh.triangles = triangles;
        
        _mesh.RecalculateBounds();
        _mesh.RecalculateNormals();
        
        TimeSpan timePassed = DateTime.UtcNow - startTime;
    }
}
