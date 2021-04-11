using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter : MonoBehaviour
{
    Noise noise = new Noise();

    public float Evaluate(Vector3 point)
    {
        return noise.Evaluate((new Vector3(point.x + 1, point.y + 1, point.z + 1)) * .5f);
    }
}
