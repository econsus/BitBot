using System.Collections;
using UnityEngine;

public class PlaySoundOnLoad : MonoBehaviour
{
    public string soundName;
    public float startDelay = 0f;
    private AudioManager am;

    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
    }
    private void Start()
    {
        StartCoroutine(PlaySoundAfterDelay(startDelay));
    }

    IEnumerator PlaySoundAfterDelay(float t)
    {
        yield return new WaitForSeconds(t);
        am.PlaySound(soundName);
    }
}
