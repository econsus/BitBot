using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void PlaySound(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.clipName == soundName);

        if(s == null)
        {
            Debug.Log(soundName + " clip not found");
        }
        else
        {
            s.source.Play();
        }
    }

    public void PlaySound(AudioClip clip)
    {
        Sound s = Array.Find(sounds, sound => sound.clip == clip);

        if (s == null)
        {
            Debug.Log(clip.name + " clip not found");
        }
        else
        {
            s.source.Play();
        }
    }
    
}
