using UnityEngine;

public class LavaAnimator : MonoBehaviour
{
    // Scroll the main texture based on time

    [SerializeField] private float fadeCooldown = 0.05f;
    [SerializeField] private float minLightLevel = 0.60f;

    private Renderer rend;

    float li = 0;
    bool liAddPositive = true;
    float lastTic = 0;

    void Start()
    {
        rend = GetComponent<Renderer>();
        li = 1;
    }

    void LateUpdate()
    {

        if (lastTic < Time.time - fadeCooldown)
        {
            rend.material.color = new Color(li, li - 0.3f, li - 0.3f, 1); // -0.3f to make it red to match lava color in terrain

            switch (liAddPositive)
            {
                case true:
                    li += 0.01f;
                    break;
                case false:
                    li -= 0.01f;
                    break;
            }

            if (li > 0.92f) liAddPositive = false;
            if (li < minLightLevel) liAddPositive = true;

            lastTic = Time.time;
        }
    }

}
