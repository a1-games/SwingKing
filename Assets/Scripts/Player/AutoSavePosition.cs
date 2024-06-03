using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSavePosition : MonoBehaviour
{
    private Vector3 savedPosition;
    private Quaternion savedRotation;
    [SerializeField] private float timeBetweenEachSave = 0.3f;

    public void Start()
    {
        float x_Pos = PlayerPrefs.GetFloat("SavedPosX", 0);
        float y_Pos = PlayerPrefs.GetFloat("SavedPosY", 0);
        float z_Pos = PlayerPrefs.GetFloat("SavedPosZ", 0);
        savedPosition = new Vector3(x_Pos, y_Pos, z_Pos);

        if (savedPosition == Vector3.zero) return;


        float x_Rot = PlayerPrefs.GetFloat("SavedRotX", 0);
        float y_Rot = PlayerPrefs.GetFloat("SavedRotY", 0);
        float z_Rot = PlayerPrefs.GetFloat("SavedRotZ", 0);
        float w_Rot = PlayerPrefs.GetFloat("SavedRotW", 0);
        savedRotation = new Quaternion(x_Rot, y_Rot, z_Rot, w_Rot);



        transform.position = savedPosition;
        transform.localRotation = savedRotation;
    }

    private float savedTime = 0f;
    public void LateUpdate()
    {
        if (timeBetweenEachSave + savedTime < Time.time)
        {
            SavePosToPlayerPref(transform.position);
            SaveRotToPlayerPref(transform.localRotation);
            savedTime = Time.time;
        }
    }

    public void SavePosToPlayerPref(Vector3 input)
    {
        PlayerPrefs.SetFloat("SavedPosX", input.x);
        PlayerPrefs.SetFloat("SavedPosY", input.y);
        PlayerPrefs.SetFloat("SavedPosZ", input.z);

    }
    public void SaveRotToPlayerPref(Quaternion input)
    {
        PlayerPrefs.SetFloat("SavedRotX", input.x);
        PlayerPrefs.SetFloat("SavedRotY", input.y);
        PlayerPrefs.SetFloat("SavedRotZ", input.z);
        PlayerPrefs.SetFloat("SavedRotW", input.w);

    }
}
