using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBackgroundAnimator : MonoBehaviour
{
    // Scroll the main texture based on time

    [SerializeField] [Range(0, 0.1f)] float scrollSpeedX = 0.5f;
    [SerializeField] [Range(0, 0.1f)] float scrollSpeedY = 0.5f;

    private MeshRenderer rend;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;
        rend.material.mainTextureOffset = new Vector2(offsetX, -offsetY);

    }

}
