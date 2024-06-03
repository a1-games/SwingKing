using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlunger : MonoBehaviour
{

    public void Start()
    {
        if (PlayerPrefs.GetInt("HasFoundPlunger", 0) > 0)
        {
            Death();
        }
    }

    [SerializeField] private GameObject toRemoveOnTriggerEnter;

    [SerializeField] private GrapplingGun grapplingGun;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Death();
            grapplingGun.ActivatePlunger(true);
        }
    }

    public void Death()
    {
        Destroy(toRemoveOnTriggerEnter);
    }
}
