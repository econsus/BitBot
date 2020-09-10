using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Options_Script : MonoBehaviour
{
    public AudioMixer audiomixer;
    public void setVolume(float volume)
    {
        audiomixer.SetFloat("MasterVolume", volume);
    }

    public void setFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
