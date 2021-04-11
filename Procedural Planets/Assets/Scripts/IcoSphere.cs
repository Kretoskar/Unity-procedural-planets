using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcoSphere : MeshData
{
    [SerializeField] [Range(0,100)] private int _accuracy = 3;

    private int _index;
    private List<Vector3> _vertices;
    private List<int> _triangles;
    private Dictionary<Int64, int> _middlePointIndexCache;
    
    public override List<Vector3> Vertices()
    {
        _middlePointIndexCache = new Dictionary<long, int>();
        _vertices = new List<Vector3>();
        
        foreach (var vertex in Icosahedron.GetVertices())
        {
            AddVertex(vertex);
        }

        _triangles = Icosahedron.GetTriangles();

        RefineTriangles();
        
        return _vertices;
    }

    public override List<int> Triangles()
    {
        return _triangles;
    }

    private void RefineTriangles()
    {
        List<int> newTriangles = new List<int>();
        
        for (int i = 0; i < _accuracy; i++)
        {
            for (int j = 0; j < _triangles.Count; j += 3)
            {
                int a = GetMiddlePoint(_triangles[j], _triangles[j + 1]);
                int b = GetMiddlePoint(_triangles[j + 1], _triangles[j + 2]);
                int c = GetMiddlePoint(_triangles[j + 2], _triangles[j]);

                newTriangles.Add(_triangles[j]);
                newTriangles.Add(a);
                newTriangles.Add(c);
                
                newTriangles.Add(_triangles[j+1]);
                newTriangles.Add(b);
                newTriangles.Add(a);
                
                newTriangles.Add(_triangles[j+2]);
                newTriangles.Add(c);
                newTriangles.Add(b);
                
                newTriangles.Add(a);
                newTriangles.Add(b);
                newTriangles.Add(c);
            }
            
            _triangles = new List<int>(newTriangles);
            newTriangles.Clear();
        }
    }
    
    //Add vertex and make sure it's on unit sphere
    private int AddVertex(Vector3 point)
    {
        float length = Mathf.Sqrt(point.x * point.x + point.y * point.y + point.z * point.z);
        _vertices.Add(new Vector3(point.x / length, point.y / length, point.z / length));
        return _index++;
    }
    
    private int GetMiddlePoint(int p1, int p2)
    {
        // first check if we have it already
        bool firstIsSmaller = p1 < p2;
        Int64 smallerIndex = firstIsSmaller ? p1 : p2;
        Int64 greaterIndex = firstIsSmaller ? p2 : p1;
        Int64 key = (smallerIndex << 32) + greaterIndex;

        int ret;
        
        if (_middlePointIndexCache.TryGetValue(key, out ret))
        {
            return ret;
        }

        // not in cache, calculate it
        Vector3 point1 = _vertices[p1];
        Vector3 point2 = _vertices[p2];
        Vector3 middle = new Vector3(
            (point1.x + point2.x) / 2, 
            (point1.y + point2.y) / 2, 
            (point1.z + point2.z) / 2);

        // add vertex makes sure point is on unit sphere
        int i = AddVertex(middle); 

        // store it, return index
        _middlePointIndexCache.Add(key, i);
        return i;
    }
}
