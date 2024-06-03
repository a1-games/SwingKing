using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatform : MonoBehaviour
{
    [SerializeField] private Material idleMat;
    [SerializeField] private Material transparentMat;

    private void Start()
    {
        GetComponent<MeshRenderer>().material = idleMat;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material = transparentMat;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material = idleMat;
        }
    }

}
