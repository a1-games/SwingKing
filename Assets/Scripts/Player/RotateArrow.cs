using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArrow : MonoBehaviour
{
    [SerializeField] private GameObject plungerHead;

    private float passedTime;

    void Update()
    {
        if (!plungerHead.activeSelf) return;//only do it if active
        passedTime += Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(passedTime * 60, 120) - 60);
    }
}
