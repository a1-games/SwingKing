using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPortal : MonoBehaviour
{
    [SerializeField] private Transform PortalDestination;

    public void OnTriggerEnter(Collider other)
    {
        //other.getcomponent<something>).death();
        print("player entered portal!");
    }
}
