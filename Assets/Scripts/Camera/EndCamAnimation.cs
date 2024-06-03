using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCamAnimation : MonoBehaviour
{
    public bool gameIsOver;
    Vector3 newPos;
    Quaternion newRotQ;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.gameObject.GetComponent<Camera>().enabled = false;
        /*
        Vector3 startPos = new Vector3(13.4099998f, -52.7000008f, -10.29f);
        Vector3 startRotEuler = new Vector3(6.49020243f, 357.518341f, 359.71933f);
        */
        newPos = new Vector3(13.2f, -54.5f, -9.8f);
        newRotQ = new Quaternion(-0.192324981f, 0f, 0f, 0.981331348f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(gameIsOver) FadeToLookUp();
    }

    public void FadeToLookUp()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, newRotQ, 0.2f * Time.deltaTime);
        transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, 0.2f * Time.deltaTime);
    }
}
