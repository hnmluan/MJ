using System;
using UnityEngine;


public class AudioController : Singleton<AudioController>
{
    [SerializeField] protected Audio[] musicSounds;

    [SerializeField] protected Audio[] sfxSounds;

    [SerializeField] protected Audio[] animalSounds;

    [SerializeField] protected AudioSource musicSource;

    [SerializeField] protected AudioSource sfxSource;

    [SerializeField] protected AudioSource animalSource;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMusicSource();
        this.LoadSFXSource();
        this.LoadAnimalSource();
    }

    private void LoadAnimalSource()
    {
        if (this.animalSource != null) return;
        animalSource = transform.Find("AnimalSource").GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadAnimalSource", gameObject);
    }

    private void LoadSFXSource()
    {
        if (this.sfxSource != null) return;
        sfxSource = transform.Find("SFXSource").GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadSFXSource", gameObject);
    }

    private void LoadMusicSource()
    {
        if (this.musicSource != null) return;
        musicSource = transform.Find("MusicSource").GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadMusicSource", gameObject);
    }

    protected override void Start() => PlayMusic("music_back_ground_free");

    public void PlayMusic(string name)
    {
        Audio s = Array.Find(musicSounds, x => x.name == name);

        if (s == null) Debug.Log(transform.name + ": Music" + name + "not found", gameObject);
        else
        {
            musicSource.clip = s.audio;
            musicSource.Play();
        }
    }

    public void PlayVFX(string name)
    {
        Audio s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null) Debug.Log(transform.name + " : VFX" + name + "not found", gameObject);
        else sfxSource.PlayOneShot(s.audio);
    }

    public void PlayAnimalSound(string name)
    {
        Audio s = Array.Find(animalSounds, x => x.name == name);

        if (s == null) Debug.Log(transform.name + ": Animal sound" + name + "not found", gameObject);
        else animalSource.PlayOneShot(s.audio);
    }

    public void ToggleMusic() => musicSource.mute = !musicSource.mute;

    public void ToggleSFX() => sfxSource.mute = !sfxSource.mute;

    public void MusicVolume(float volume) => musicSource.volume = volume;

    public float MusicVolume() => musicSource.volume;

    public void SFXVolume(float volume) => sfxSource.volume = volume;

    public float SFXVolume() => sfxSource.volume;

    public void AnimalVolume(float volume) => animalSource.volume = volume;

    public float AnimalVolume() => animalSource.volume;
}
