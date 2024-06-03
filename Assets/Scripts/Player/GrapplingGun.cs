using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplingGun : MonoBehaviour
{
    //private bool hasFoundPlunger = false; saved in playerprefs instead
    [SerializeField] private GameObject plungerToHide;
    [HideInInspector] public bool canShoot = true;
    [SerializeField] private GameObject plungerModelStatic;
    public float maxRopeLength = 5f;
    public Transform hookSpawnPoint;
    public Transform ropeAnchorPoint;
    public Transform ropeAttachPoint;
    public Transform player;
    [SerializeField] private GameObject hook;
    public float hookFireSpeed = 2f;
    [SerializeField] private float shootCooldown = 1f;
    private GameObject spawnedHook;

    public LineRenderer lr;
    //[SerializeField] private LayerMask grabbableSurface;
    private Vector3 grapplePoint;
    private SpringJoint joint;

    private bool shootToggle;

    public void Start()
    {
        lr.positionCount = 2;

        if ( PlayerPrefs.GetInt("HasFoundPlunger", 0) > 0 )
        {
            plungerToHide.SetActive(true);
            canShoot = true;
        }
        else
        {
            plungerToHide.SetActive(false);
            canShoot = false;
        }
    }


    private bool ropePos1_hasChanged = false;
    public void LateUpdate()
    {
        if (plungerModelStatic.activeSelf)
        {
            ChangeRopePos2(ropeAttachPoint.position);
        }

        DrawRope();
    }

    private float savedShootCooldown = 0f;
    public void Shoot(InputAction.CallbackContext context)
    {
        if (!canShoot) return;
        
        if (savedShootCooldown + shootCooldown > Time.time)
        {
            return;
        }

        if (context.performed)
        {
            switch (God.AskFor.activeHooks.Count)
            {
                case 0:
                    {
                        //print(God.AskFor.activeHooks.Count);
                        Vector3 rotEuler = this.transform.rotation.eulerAngles;
                        spawnedHook = Instantiate(hook, hookSpawnPoint.position, Quaternion.Euler(rotEuler.x, rotEuler.y, rotEuler.z - 180));
                        God.AskFor.activeHooks.Add(spawnedHook);
                        spawnedHook.GetComponent<Rigidbody>().velocity = this.transform.up * hookFireSpeed;
                        spawnedHook.GetComponent<Hook>().gun = this;
                        spawnedHook.GetComponent<Hook>().joint = this.joint;
                        spawnedHook.GetComponent<Collider>().enabled = true;

                        plungerModelStatic.SetActive(false);
                    }
                    break;
                case 1:
                    {
                        //print(God.AskFor.activeHooks.Count);
                        RecallHook();
                    }
                    break;
            }

            savedShootCooldown = Time.time;
        }
    }

    public void RecallHook()
    {
        if (joint) Destroy(this.joint);
        spawnedHook.GetComponent<Hook>().recall = true;
        spawnedHook.GetComponent<Hook>().lerpRotation = true;
        spawnedHook.GetComponent<Collider>().enabled = false;
    }

    public SpringJoint StartGrapple(Vector3 pos)
    {
        //player.GetComponent<MovementController>().isPulling = true;

        grapplePoint = pos;

        joint = player.gameObject.AddComponent<SpringJoint>();
        joint.anchor = ropeAnchorPoint.localPosition; //new Vector3(0, 1f, 0);
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = grapplePoint;

        float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);
        joint.maxDistance = distanceFromPoint * 0.14f;
        joint.minDistance = distanceFromPoint * 0.01f;

        joint.spring = 24f;
        joint.damper = 12f;
        joint.massScale = 10f;

        player.GetComponent<MovementController>().UnfreezeRotation();
        return joint;
    }

    public void StopGrapple()
    {
        //shootToggle = false;
        plungerModelStatic.SetActive(true);
    }

    [HideInInspector] public Vector3 line_2_Pos;
    public void DrawRope()
    {
        lr.SetPosition(0, ropeAnchorPoint.position);
        lr.SetPosition(1, line_2_Pos);
    }

    public void ChangeRopePos2(Vector3 inputPos)
    {
        line_2_Pos = inputPos;
    }

    public void ActivatePlunger(bool foundPlunger)
    {
        int value = 0;
        if (foundPlunger) value = 10;

        PlayerPrefs.SetInt("HasFoundPlunger", value);
        plungerToHide.SetActive(foundPlunger);
        canShoot = foundPlunger;
    }
}
