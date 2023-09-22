using UnityEngine;


public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private string defaultBackgroundMusic;

    public const string MASTER_VOLUME = "MasterVolume";

    public const string MUSIC_VOLUME = "MusicVolume";

    public const string SFX_VOLUME = "SFXVolume";

    public const string UI_VOLUME = "UIVolume";

    public const string DIALOG_VOLUME = "DialogVolume";

    private AudioSource musicSource;

    private AudioSource sfxSource;

    private AudioSource uiSource;

    public AudioSource dialogueSource;

    protected override void Awake()
    {
        if (musicSource == null) musicSource = gameObject.AddComponent<AudioSource>();
        if (sfxSource == null) sfxSource = gameObject.AddComponent<AudioSource>();
        if (uiSource == null) uiSource = gameObject.AddComponent<AudioSource>();
        if (dialogueSource == null) dialogueSource = gameObject.AddComponent<AudioSource>();

        musicSource.volume = MusicVolume;
        sfxSource.volume = SFXVolume;
        uiSource.volume = UIVolume;
        dialogueSource.volume = DialogVolume;
        musicSource.loop = true;
    }

    protected override void Start() => PlayDefaultMusic();

    public void PlayDefaultMusic() => AudioManager.Instance.Play(defaultBackgroundMusic);

    public float MasterVolume
    {
        get => PlayerPrefs.HasKey(MASTER_VOLUME) ? PlayerPrefs.GetFloat(MASTER_VOLUME) : 1.0f;
        set
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME, value);
            musicSource.volume = MusicVolume;
            sfxSource.volume = SFXVolume;
            uiSource.volume = UIVolume;
            dialogueSource.volume = DialogVolume;
        }
    }

    public float MusicVolume
    {
        get => (PlayerPrefs.HasKey(MUSIC_VOLUME) ? PlayerPrefs.GetFloat(MUSIC_VOLUME) : 1.0f) * MasterVolume;
        set
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME, value);
            musicSource.volume = MusicVolume;
        }
    }

    public float SFXVolume
    {
        get => (PlayerPrefs.HasKey(SFX_VOLUME) ? PlayerPrefs.GetFloat(SFX_VOLUME) : 1.0f) * MasterVolume;
        set
        {
            PlayerPrefs.SetFloat(SFX_VOLUME, value);
            sfxSource.volume = SFXVolume;
        }
    }

    public float UIVolume
    {
        get => (PlayerPrefs.HasKey(UI_VOLUME) ? PlayerPrefs.GetFloat(UI_VOLUME) : 1.0f) * MasterVolume;
        set
        {
            PlayerPrefs.SetFloat(UI_VOLUME, value);
            uiSource.volume = UIVolume;
        }
    }

    public float DialogVolume
    {
        get => (PlayerPrefs.HasKey(DIALOG_VOLUME) ? PlayerPrefs.GetFloat(DIALOG_VOLUME) : 1.0f) * MasterVolume;
        set
        {
            PlayerPrefs.SetFloat(DIALOG_VOLUME, value);
            dialogueSource.volume = DialogVolume;
        }
    }

    public void Play(string name)
    {
        AudioAsset audioAsset = Resources.Load<AudioAsset>("AudioAssets/" + name);

        if (audioAsset == null)
        {
            Debug.Log(transform.name + ": Music" + name + "not found", gameObject);
            return;
        }

        Play(audioAsset);
    }

    private void Play(AudioAsset audioAsset)
    {
        if (audioAsset.Mixer == AudioAsset.MixerGroup.SFX) Play(sfxSource, audioAsset.AudioClip);
        if (audioAsset.Mixer == AudioAsset.MixerGroup.UI) Play(uiSource, audioAsset.AudioClip);
        if (audioAsset.Mixer == AudioAsset.MixerGroup.Music) Play(musicSource, audioAsset.AudioClip);
    }

    private void Play(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
