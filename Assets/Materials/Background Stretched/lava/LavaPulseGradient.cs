using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPulseGradient : MonoBehaviour
{
    [SerializeField] private Color colorTop = Color.white;
    [SerializeField] private Color colorBottom = Color.black;
    void Update()
    {
        MeshFilter thisMeshFilter = GetComponent<MeshFilter>();
        thisMeshFilter.mesh.colors = new Color[] { colorTop, colorTop, colorBottom, colorBottom };
    }

}
