using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : MonoBehaviour, ICanShoot
{
    public void Shoot(float angle, GameObject gunEndpoint)
    {
        //start semi auto coroutine
        Debug.Log("Auto Bang Bang");
    }
}
