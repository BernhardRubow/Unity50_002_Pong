using UnityEngine;

[CreateAssetMenu(fileName = "SimpleAudioEvent", menuName = "NVP/Pong/Audio/SimpleAudioEvent", order = 2)]
public class NvpSimpleAudioEvent : ScriptableObject, IAudioEvent
{
    public AudioClip[] clips;

    public float minVolume = 1f;
    public float maxVolume = 1f;

    public float minPitch = 1f;
    public float maxPitch = 1f;

    public void Play(AudioSource source)
    {
        if (clips.Length == 0) return;

        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = Random.Range(minVolume, maxVolume);
        source.pitch = Random.Range(minPitch, maxPitch);
        source.Play();
    }
}