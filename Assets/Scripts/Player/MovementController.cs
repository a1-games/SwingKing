
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [HideInInspector] public bool canMove = true;
    //public InputMaster controls;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed = 1000f;
    [SerializeField] private float jumpForce = 2f;
    private float x_Axis = 0;
    [HideInInspector] public bool isPulling;
    [HideInInspector] public Vector3 targetPosition;
    [HideInInspector] public Quaternion defaultRotation;
    [Header("groundcheck")]
    [SerializeField] private Transform groundCheckLeft;
    [SerializeField] private Transform groundCheckRight;
    [SerializeField] private Transform strandedCheckPos;
    [SerializeField] private LayerMask layerMask;



    void Start()
    {
        defaultRotation = new Quaternion(0, 0, 0, 1);
        //FreezeRotation();
    }

    private bool IsGrounded()
    {
        Vector3 down = transform.TransformDirection(Vector3.down);
        return Physics.Raycast(groundCheckLeft.transform.position, down, groundCheckRayLength, layerMask) || Physics.Raycast(groundCheckRight.transform.position, down, groundCheckRayLength, layerMask);
        //Debug.DrawRay(groundCheckLeft.transform.position, down.normalized * groundCheckRayLength, Color.green);
        //Debug.DrawRay(groundCheckRight.transform.position, down.normalized * groundCheckRayLength, Color.green);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!canMove) return;
        if (context.performed)
        {
            if (IsGrounded())
            {
                rb.AddForce(transform.up * jumpForce);
                UnfreezeRotation();
                canMove = false;
            }
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        if (!canMove) return;
        x_Axis = context.ReadValue<float>();
    }


    private void OnIsMoving()
    {
        print("is moving with controls");
    }

    private void OnStoppedMoving()
    {
        print("stopped moving with controls");
    }
    private void OnLandedJump()
    {
        print("landed jump");
        canMove = true;
    }

    private Vector3 lastRot = Vector3.zero;
    private float lastRotCheckTime = 0f;
    private void CheckForCrash()
    {
        lastRotCheckTime = Time.time;
        lastRot = transform.rotation.eulerAngles;
        her var jeg sidst
    }
    private void OnCrash()
    {
        print("crashed");

        var colobjects = Physics.OverlapSphere(strandedCheckPos.position, 0.8f, layerMask);
        if (colobjects.Length != 0)
        {
            ResetRotation();
        }
        // wait until we lie still for 1.5 secs, then
        ResetRotation();
    }






    private float groundCheckRayLength = 1.3f;
    public void FixedUpdate() //raycast groundcheck
    {
        CallMovement();
    }

    private void CallMovement()
    {
        if (canMove)
        {
            rb.velocity = new Vector3(x_Axis * moveSpeed * Time.fixedDeltaTime, rb.velocity.y, rb.velocity.z);
            if (x_Axis != 0f)
                OnIsMoving();
        }

        CheckForCrash();
    }


    [HideInInspector] public bool rotationResetIsActive = false;


    public void ResetRotation()
    {
        if (isResettingRotation) return;
        StartCoroutine(RotReset());
    }
    private bool isResettingRotation = false;
    private IEnumerator RotReset()
    {
        isResettingRotation = true;

        var startRot = transform.rotation;
        float lerpFloat = 0f;

        FreezeRotation();

        while (true)
        {
            yield return new WaitForEndOfFrame();
            lerpFloat += Time.deltaTime * 0.2f;
            transform.rotation = Quaternion.Lerp(startRot, defaultRotation, lerpFloat);

            if (lerpFloat >= 1f)
                break;
        }

        canMove = true;
        isResettingRotation = false;
    }

    public void FreezeRotation()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
    public void UnfreezeRotation()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }
            
}
