using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icosahedron
{
    private List<Vector3> _vertices;
    private List<Vector3> _faces;

    public Icosahedron()
    {
        _vertices = new List<Vector3>();
        _faces = new List<Vector3>();
    }
    
    private void GetVertices()
    {
        float t = (1 + Mathf.Sqrt(5)) / 2;
     
        _vertices.Add(new Vector3(-1, t, 0));
        _vertices.Add(new Vector3(1, t, 0));
        _vertices.Add(new Vector3(-1, -t, 0));
        _vertices.Add(new Vector3(-1, -t, 0));
        
        _vertices.Add(new Vector3(0, -1, t));
        _vertices.Add(new Vector3(0, 1, t));
        _vertices.Add(new Vector3(0, -1, -t));
        _vertices.Add(new Vector3(0, 1, -t));
        
        _vertices.Add(new Vector3(t, 0, -t));
        _vertices.Add(new Vector3(t, 0, 1));
        _vertices.Add(new Vector3(-t, 0, -1));
        _vertices.Add(new Vector3(-t, 1, 1));
    }

    private void GetFaces()
    {
        //given parameters are indexes of vertices on _vertices list
        _faces.Add(new Vector3(0,11,5));
        _faces.Add(new Vector3(0,5,1));
        _faces.Add(new Vector3(0,1,7));
        _faces.Add(new Vector3(0,7,10));
        _faces.Add(new Vector3(0,10,11));
        
        _faces.Add(new Vector3(1,5,9));
        _faces.Add(new Vector3(5,11,4));
        _faces.Add(new Vector3(11,10,2));
        _faces.Add(new Vector3(10,7,6));
        _faces.Add(new Vector3(7,1,8));
        
        _faces.Add(new Vector3(3,9,4));
        _faces.Add(new Vector3(3,4,2));
        _faces.Add(new Vector3(3,2,6));
        _faces.Add(new Vector3(3,6,8));
        _faces.Add(new Vector3(3,8,9));
        
        _faces.Add(new Vector3(4,9,5));
        _faces.Add(new Vector3(2,4,11));
        _faces.Add(new Vector3(6,2,10));
        _faces.Add(new Vector3(8,6,7));
        _faces.Add(new Vector3(9,8,1));
    }
}
