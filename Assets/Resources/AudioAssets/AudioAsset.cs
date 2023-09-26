using UnityEngine;


[CreateAssetMenu(fileName = "AudioAsset", menuName = "ScriptableObject/AudioAsset")]
public class AudioAsset : ScriptableObject
{
    public enum MixerGroup
    {
        Master,
        Music,
        SFX,
        UI
    }

    [field: SerializeField] public AudioClip AudioClip { get; private set; }
    [field: SerializeField] public MixerGroup Mixer { get; private set; }
}
