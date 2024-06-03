using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEndCamera : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] Camera endCam;

    public void ActivateCam()
    {
        mainCam.enabled = false;
        endCam.enabled = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ActivateCam();
        }
    }
}
