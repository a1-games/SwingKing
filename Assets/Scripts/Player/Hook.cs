using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Transform ropeAttach;
    public Transform coinAttach;

    [Header("Grappling Gun")]
    [HideInInspector] public bool lerpRotation;
    [HideInInspector] public GrapplingGun gun;
    [HideInInspector] public bool recall;
    [HideInInspector] public Joint joint;

    private bool isGrapplingSurface;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grabbable")
        {
            if (joint) return; // don't make another joint if there is already one
            joint = gun.StartGrapple(ropeAttach.position);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            lerpRotation = true;
            isGrapplingSurface = true;
        }

        if (other.gameObject.tag == "Coin")
        {
            print("sedf");
            gun.RecallHook();
            other.transform.parent = coinAttach;
            other.transform.localPosition = Vector3.zero;
            other.transform.localScale *= 0.8f;
            other.transform.GetComponent<Coin>().highlightEffect.glowVisibility = HighlightPlus.Visibility.Normal;
            other.transform.GetComponent<Coin>().highlightEffect.UpdateMaterialProperties();
        }

    }

    /*
     * --- JOINT ERROR: ---
     * rope reaches maxlength right before it hits a surface, which means the script thinks it is recalling, when in fact it is pulling.
     * this activates the recall part of update, which means that if the player gets pulled too close to the anchorpoint,
     * the hook dies without the grapplingun script killing the joint first.
     */

    public void Update()
    {
        if (recall)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Vector3 test = gun.hookSpawnPoint.position - transform.position;
            GetComponent<Rigidbody>().velocity = test.normalized * gun.hookFireSpeed;

            if (Vector3.Distance(transform.position, gun.hookSpawnPoint.position) < 0.2f)
            {
                //if (isGrapplingSurface) print("entered death");
                lerpRotation = false;
                if (joint) Destroy(joint);
                Death();
            }
        }

        if (Vector3.Distance(transform.position, gun.player.position) > gun.maxRopeLength && !isGrapplingSurface)
        {
            gun.RecallHook();
        }

    }

    private void LateUpdate()
    {
        gun.ChangeRopePos2(ropeAttach.position);
        if (lerpRotation) LerpRotationToPlayer();
    }


    public void Death()
    {
        gun.StopGrapple();
        God.AskFor.activeHooks.Remove(this.gameObject);
        if (joint) Destroy(joint); // if there is a joint, destroy it
        if (coinAttach.childCount > 0)
        {
            coinAttach.GetChild(0).GetComponent<Coin>().Death();
        }

        Destroy(this.gameObject);
    }

    public void LerpRotationToPlayer()
    {
        Quaternion lookAt = Quaternion.LookRotation(God.AskFor.player.transform.position - this.transform.position, Vector3.up);
        Vector3 lookRotEuler = lookAt.eulerAngles;

        this.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(lookRotEuler.x + 90, lookRotEuler.y, lookRotEuler.z), 100f * Time.deltaTime);
    }
}
