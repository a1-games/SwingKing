using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public HighlightPlus.HighlightEffect highlightEffect;

    private Renderer rend;
    private Vector3 targetPos;
    [SerializeField] private GameObject collectedCoin;

    [HideInInspector] public bool isMoving;

    //[HideInInspector] public Quaternion startRot;

    public void Start()
    {
        rend = GetComponent<Renderer>();
        //startRot = transform.rotation;
    }
    /*
    public void LateUpdate()
    {
        if (!isMoving) return;
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime);
        print("islerping : " + transform.localPosition);
    }


    public void ChangeLerpPosTarget(Vector3 target)
    {
        targetPos = target;
    }
    */
    public void Death()
    {
        God.AskFor.coins++;
        God.AskFor.RefreshCoinUI();
        Instantiate(collectedCoin, transform.position, transform.rotation);
        //Destroy(this.gameObject);
    }


}
