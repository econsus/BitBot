// ----------------------------------------------------------------------------
// Author: Wahyu Candra
// Date:   05/02/2021
// ----------------------------------------------------------------------------
using UnityEngine;

//Scriptable object untuk menyimpan nilai Vector3
[CreateAssetMenu(fileName = "New Vector3 Variable", menuName = "Scriptable Objects/Variables/Vector3 Variable")]
public class Vector3Variable : ScriptableObject, ISerializationCallbackReceiver
{
    [Multiline]
    public string description;

    public Vector3 currentValue;
    public Vector3 defaultValue;
    public bool resetOnDeserialize; //Reset variabel ke nilai default setelah deserialize?
    public void SetValue(Vector3 value)
    {
        currentValue = value;
    }
    public void SetValue(Vector3Variable value)
    {
        currentValue = value.currentValue;
    }
    public void SetDefaultValue(Vector3 value)
    {
        defaultValue = value;
    }
    public void SetDefaultValue(Vector3Variable value)
    {
        defaultValue = value.currentValue;
    }
    public void OnBeforeSerialize() { }
    public void OnAfterDeserialize()
    {
        currentValue = resetOnDeserialize ? defaultValue : currentValue; //Me-reset variabel ke nilai default
    }
}

