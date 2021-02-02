using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vector Value", menuName = "Scriptable Objects/Storages/Vector Value")]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 initialValue;
    public Vector2 defaultValue;

    public void OnBeforeSerialize() { }
    public void OnAfterDeserialize()
    {
        initialValue = defaultValue;
    }
}
