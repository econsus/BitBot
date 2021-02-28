using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleInput : MonoBehaviour
{
    private List<KeyCode> doubleTappedKeys = new List<KeyCode>();
    private List<KeyCode> releasedKeys = new List<KeyCode>();
    private Dictionary<KeyCode, float> keycodesByLifespan = new Dictionary<KeyCode, float>();
    private EventManager em;

    private void Awake()
    {
        em = FindObjectOfType<EventManager>();
    }

    private void Update()
    {
        DetectPressedKeycode();
    }
    private void DetectPressedKeycode()
    {
        foreach (KeyCode keycodes in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keycodes))
            {
                DoubleTapCheck(keycodes);
            }
            if(Input.GetKeyUp(keycodes))
            {
                RemoveDoubleTap(keycodes);
            }
        }
    }
    private void DoubleTapCheck(KeyCode kcode)
    {
        if (!keycodesByLifespan.ContainsKey(kcode))
        {
            keycodesByLifespan.Add(kcode, 0f);
        }
        if (keycodesByLifespan[kcode] == 0f || releasedKeys.Contains(kcode))
        {
            if (Time.time < keycodesByLifespan[kcode])
            {
                if (!doubleTappedKeys.Contains(kcode))
                {
                    doubleTappedKeys.Add(kcode);
                    em.OnDoubleTapEventMethod(kcode);
                }
            }
            if(releasedKeys.Contains(kcode))
            {
                releasedKeys.Remove(kcode);
            }
            keycodesByLifespan[kcode] = Time.time + 0.175f;
        }
    }
    private void RemoveDoubleTap(KeyCode kcode)
    {
        if (doubleTappedKeys.Contains(kcode))
        {
            doubleTappedKeys.Remove(kcode);
        }
        if (!releasedKeys.Contains(kcode))
        {
            releasedKeys.Add(kcode);
        }
    }
}
