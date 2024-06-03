using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    
    public void StartEndThemeSong()
    {
        MusicPlayer.AskFor.jukebox.clip = sound;
        MusicPlayer.AskFor.jukebox.Play();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartEndThemeSong();
        }
    }
}
