using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndSequence : MonoBehaviour
{
    [SerializeField] private EndCamAnimation endcam;
    [SerializeField] private MeshRenderer quadBackgroundMeshRenderer;
    [SerializeField] private GrapplingGun gun;
    [SerializeField] private MovementController playerMovement;

    private bool lerpAlpha;
    private float alphaFloat;
    [SerializeField] private float duration;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerMovement.canMove = false;
            gun.canShoot = false;
            StartCoroutine(IStart());
        }
    }



    private IEnumerator IStart()
    {
        yield return new WaitForSeconds(6f);
        endcam.gameIsOver = true;
        lerpAlpha = true;
    }


    public void LerpAlpha()
    {
        if (alphaFloat > 1) return;
        alphaFloat += duration/100 * Time.deltaTime;

        quadBackgroundMeshRenderer.material.color = new Color (0.55f, 0.55f, 0.55f, alphaFloat); //it's already black so no need to find out what the saved colour is
    }

    private void Update()
    {
        if (lerpAlpha) LerpAlpha();
    }
}
