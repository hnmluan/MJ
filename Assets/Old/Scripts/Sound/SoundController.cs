using System;
using UnityEngine;


public class SoundController : InitMonoBehaviour
{
    private static SoundController instance;
    public static SoundController Instance { get => instance; }


    [SerializeField] protected Sound[] musicSounds;

    [SerializeField] protected Sound[] sfxSounds;

    [SerializeField] protected AudioSource musicSource;

    [SerializeField] protected AudioSource sfxSource;

    protected override void Awake()
    {
        base.Awake();
        if (SoundController.instance != null) Debug.LogError("Only 1 SoundController allow to exist");
        SoundController.instance = this;
    }

    protected override void Start()
    {
        PlayMusic("theme");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log(transform.name + ": Music" + s.name + "not found", gameObject);
        }
        else
        {
            musicSource.clip = s.audio;
            musicSource.Play();
        }
    }

    public void PlayVFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
            Debug.Log(transform.name + ": VFX" + s.name + "not found", gameObject);
        else
            sfxSource.PlayOneShot(s.audio);
    }

    public void ToggleMusic() => musicSource.mute = !musicSource.mute;

    public void ToggleSFX() => sfxSource.mute = !sfxSource.mute;

    public void MusicVolume(float volume) => musicSource.volume = volume;

    public void SFXVolume(float volume) => sfxSource.volume = volume;
}
