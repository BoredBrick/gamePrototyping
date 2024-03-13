using Assets.Scripts;
using UnityEngine;

public class LevelAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    void Start()
    {
        audioSource.loop = true;
        audioSource.volume = Constants.defaultVolume;
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }

    public void HalfVolume()
    {
        audioSource.volume = Constants.defaultVolume / 2;
    }

    public void DefaultVolume()
    {
        audioSource.volume = Constants.defaultVolume;
    }
}
