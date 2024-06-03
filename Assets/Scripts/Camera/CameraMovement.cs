using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private bool X;
    [SerializeField] private bool Y;

    [SerializeField] [Range(-5, 5)] private float yOffset = 1f;

    private Vector3 tempVec;
    void Update()
    {
        if (X && !Y) tempVec = new Vector3(playerPos.position.x, transform.position.y + yOffset, transform.position.z);
        if (!X && Y) tempVec = new Vector3(transform.position.x, playerPos.position.y + yOffset, transform.position.z);
        if (X && Y) tempVec = new Vector3(playerPos.position.x, playerPos.position.y + yOffset, transform.position.z);

        transform.position = tempVec;
    }
}
