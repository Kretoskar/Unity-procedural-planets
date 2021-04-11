using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeshData : MonoBehaviour
{
    public abstract List<Vector3> Vertices();
    public abstract List<int> Triangles();
}
