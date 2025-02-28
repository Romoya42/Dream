using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class S_SoundManager : MonoBehaviour
{

    public S_Sound[] sounds;
    public static S_SoundManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Play("Ambiance");
        Play("Stress");
    }


    public void Play(string name)
    {
        S_Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.outputAudioMixerGroup = s.audioMixerGroup;
        s.source.clip = s.clip;
        s.source.loop = s.loop;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.Play();
    }

    public void Stop(string name)
    {
        S_Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
}
