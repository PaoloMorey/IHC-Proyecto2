using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // pokemon cry clips
    public AudioClip[] audioClips;
    private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();
    public AudioClip[] fxClips;
    private new List<AudioSource> audioSourcesFx;

    void Start()
    {
        audioSourcesFx = new List<AudioSource>();

        for (int i = 0; i < audioClips.Length; i++)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClips[i];
            audioSource.playOnAwake = false;
            audioSources[audioClips[i].name.Replace("Grito_de_", "").Replace(".ogg", "")] = audioSource;
            // Debug.Log(audioClips[i].name.Replace("Grito_de_", "").Replace(".ogg", ""));
        }

        for (int i = 0; i < fxClips.Length; i++) {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = fxClips[i];
            audioSource.playOnAwake = false;
            audioSourcesFx.Add(audioSource);
        }
    }

    public void PlayAudioSource(string key)
    {
        audioSources[key].Play();
    }

    public void PlayAudioSourceFx(int id)
    {
        audioSourcesFx[id].Play();
    }
}
