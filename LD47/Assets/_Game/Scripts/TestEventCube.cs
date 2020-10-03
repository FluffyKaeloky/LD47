using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class TestEventCube : MonoBehaviour
{
    public Material newMat = null;

    private new Renderer renderer = null;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    public void ChangeMaterial()
    {
        renderer.material = newMat;
    }
}
