using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;
    public static MusicPlayer AskFor { get => instance; }

    public AudioSource soundEffects;
    public AudioSource jukebox;

    public List<AudioClip> songs;
    public List<AudioClip> audioClips;
    public List<AudioClip> endSequenceSounds;

    private float musicVolume;
    private float soundsVolume;

    private void Awake()
    {
        instance = this;
        //start theme song
        musicVolume = PlayerPrefs.GetFloat("VOLUME_MUSIC", 0.5f);
        soundsVolume = PlayerPrefs.GetFloat("VOLUME_SOUNDS", 0.5f);
        jukebox.volume = musicVolume;
        soundEffects.volume = soundsVolume;
    }

    public void RefreshSoundSettings()
    {
        musicVolume = PlayerPrefs.GetFloat("VOLUME_MUSIC", 0.5f);
        soundsVolume = PlayerPrefs.GetFloat("VOLUME_SOUNDS", 0.5f);
    }

    public void PlaySoundEffect(AudioClip input)
    {
        soundEffects.clip = input;
        soundEffects.Play();
    }
}
