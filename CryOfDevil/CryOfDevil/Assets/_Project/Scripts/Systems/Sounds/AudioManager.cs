//using System.Collections;
//using System;
//using System.Collections.Generic;
//using UnityEngine;

//public class AudioManager : MonoBehaviour
//{
//    public Sound[] sounds;
//    public Sound[] walkingSounds;
//    public Sound[] runningSounds;
//S
//    void Awake()
//    {
//        SetupAudioSource(sounds);
//        SetupAudioSource(walkingSounds);
//        SetupAudioSource(runningSounds);
//    }

//    public void Play(string name)
//    {
//        var sound = Array.Find(sounds, sound => sound.soundName == name);
//        sound.source.Play();
//    }

//    public void PlayStepSound()
//    {
//        var source = RandomAudio(walkingSounds);
//        source.Play();
//    }

//    public void PlayRunSound()
//    {
//        var source = RandomAudio(runningSounds);
//        source.Play();
//    }
//}
