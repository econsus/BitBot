using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnEnable : MonoBehaviour
{
    [SerializeField] string soundName = "Sound Name";
    private AudioManager am;
    void Awake()
    {
        am = FindObjectOfType<AudioManager>();
    }
    private void OnEnable()
    {
        Play(soundName);
    }

    // Update is called once per frame
    void Play(string str)
    {
        am.PlaySound(str);
    }
}
