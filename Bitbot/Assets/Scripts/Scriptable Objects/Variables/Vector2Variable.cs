using UnityEngine;

//Scriptable object untuk menyimpan nilai Vector2 di memori
[CreateAssetMenu(fileName = "New Vector2 Variable", menuName = "Scriptable Objects/Variables/Vector2 Variable")]
public class Vector2Variable : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 currentValue; //Nilai Vector2 yang berubah-ubah (variabel)
    public Vector2 defaultValue; //Nilai default Vector2
    public bool resetOnDeserialize; //Reset variabel ke nilai default setelah deserialize?
    public void SetValue(Vector2 value)
    {
        this.currentValue = value;
    }
    public void SetValue(Vector2Variable value)
    {
        this.currentValue = value.currentValue;
    }
    public void OnBeforeSerialize() { }
    public void OnAfterDeserialize()
    {
        currentValue = resetOnDeserialize? defaultValue : currentValue; //Me-reset variabel ke nilai default
    }
}
