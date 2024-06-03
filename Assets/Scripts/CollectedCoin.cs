using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedCoin : MonoBehaviour
{
    [SerializeField] private float lifetime = 10f;
    [SerializeField] private float jumpForce = 3000f;
    [SerializeField] private float zPushForce;
    [SerializeField] private float negativeScaleFactor = 0.002f;

    private float timeOnSpawn;
    private Rigidbody rb;

    private Vector3 trS;
    private float scale;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward * jumpForce);
        rb.velocity += new Vector3(0, 0, zPushForce);

        timeOnSpawn = Time.time;
        scale = 1;

        transform.localScale *= 0.8f;
        trS = transform.localScale;

        MusicPlayer.AskFor.PlaySoundEffect(MusicPlayer.AskFor.audioClips[0]);
    }

    private void LateUpdate()
    {
        scale -= negativeScaleFactor * Time.deltaTime;

        transform.localScale = new Vector3(trS.x * scale, trS.y * scale, trS.z * scale);

        if (timeOnSpawn + lifetime < Time.time)
        {
            Destroy(this.gameObject);
        }
    }
}
