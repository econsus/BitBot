// ----------------------------------------------------------------------------
// Author: Wahyu Candra
// Date:   05/02/2021
// ----------------------------------------------------------------------------
using UnityEngine;
using System;

[Serializable]
public class Vector3Reference
{
    public Vector3Variable variable;

    public Vector3Reference() { }

    public Vector3 Value
    {
        get { return variable.currentValue; }
        set { variable.SetValue(value); }
    }
    public static implicit operator Vector3(Vector3Reference reference)
    {
        return reference.Value;
    }
}

