using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfAfterTime : MonoBehaviour
{
    [SerializeField] private float time = 0f;
    private void OnEnable()
    {
        Destroy(gameObject, time);
    }
}
