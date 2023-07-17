using System;
using UnityEngine;


public class AudioController : InitMonoBehaviour
{
    private static AudioController instance;
    public static AudioController Instance { get => instance; }


    [SerializeField] protected Audio[] musicSounds;

    [SerializeField] protected Audio[] sfxSounds;

    [SerializeField] protected AudioSource musicSource;

    [SerializeField] protected AudioSource sfxSource;



    protected override void Awake()
    {
        base.Awake();
        if (AudioController.instance != null) Debug.LogError("Only 1 AudioController allow to exist");
        AudioController.instance = this;
    }

    protected override void Start()
    {
        PlayMusic("music_back_ground_free");
    }

    public void PlayMusic(string name)
    {
        Audio s = Array.Find(musicSounds, x => x.name == name);

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
        Audio s = Array.Find(sfxSounds, x => x.name == name);

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
