using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetSpawnPos : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 startPos;
    // Start is called before the first frame update
    public void Start()
    {
        SetPos();
    }

    public void GoToSavedPos(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            player.transform.position = startPos;
        }
    }

    public void ResetPos(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SetPos();
        }
    }

    public void SetPos()
    {
        startPos = player.transform.position;
    }
}
