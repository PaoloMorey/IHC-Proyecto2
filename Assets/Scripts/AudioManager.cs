using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

    void Start()
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClips[i];
            audioSource.playOnAwake = false;
            audioSources[audioClips[i].name.Replace("Grito_de_", "")] = audioSource;
        }
    }

    public void PlayAudioSource(string key)
    {
        audioSources[key].Play();
    }
}
