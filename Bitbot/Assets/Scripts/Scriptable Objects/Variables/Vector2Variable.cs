using UnityEngine;

//Scriptable object untuk menyimpan nilai Vector2
[CreateAssetMenu(fileName = "New Vector2 Variable", menuName = "Scriptable Objects/Variables/Vector2 Variable")]
public class Vector2Variable : ScriptableObject, ISerializationCallbackReceiver
{
    [Multiline]
    public string description;

    public Vector2 currentValue;
    public Vector2 defaultValue;
    public bool resetOnDeserialize; //Reset variabel ke nilai default setelah deserialize?
    public void SetValue(Vector2 value)
    {
        currentValue = value;
    }
    public void SetValue(Vector2Variable value)
    {
        currentValue = value.currentValue;
    }
    public void SetDefaultValue(Vector2 value)
    {
        defaultValue = value;
    }
    public void SetDefaultValue(Vector2Variable value)
    {
        defaultValue = value.currentValue;
    }
    public void OnBeforeSerialize() { }
    public void OnAfterDeserialize()
    {
        currentValue = resetOnDeserialize? defaultValue : currentValue; //Me-reset variabel ke nilai default
    }
}
