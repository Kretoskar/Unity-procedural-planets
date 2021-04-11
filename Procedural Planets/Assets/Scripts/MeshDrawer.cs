using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshDrawer : MonoBehaviour
{
    [SerializeField] private MeshData _meshData = null;

    private Mesh _mesh;
    private NoiseFilter _noiseFilter;

    private void Start()
    {
        _noiseFilter = new NoiseFilter();
        
        DateTime startTime = DateTime.UtcNow;

        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        
        _mesh.Clear();

        List<Vector3> vertices = _meshData.Vertices();
        int[] triangles = _meshData.Triangles().ToArray();
        
        
        List<Vector3> verticesAfterElevation = new List<Vector3>();
        
        foreach (Vector3 v in vertices)
        {
            float elevation = _noiseFilter.Evaluate(v);
            verticesAfterElevation.Add(v * (1 + elevation));
        }
        
        _mesh.vertices = verticesAfterElevation.ToArray();
        _mesh.triangles = triangles;
        
        _mesh.RecalculateBounds();
        _mesh.RecalculateNormals();
        
        TimeSpan timePassed = DateTime.UtcNow - startTime;
    }
}
