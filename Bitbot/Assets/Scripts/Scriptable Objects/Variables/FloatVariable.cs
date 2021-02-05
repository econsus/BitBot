using UnityEngine;

[CreateAssetMenu(fileName = "New Float Variable", menuName = "Scriptable Objects/Variables/Float Variable")]
public class FloatVariable : ScriptableObject
{
    [Multiline]
    public string description;

    public float value;

    public void SetValue(float replacement)
    {
        value = replacement;
    }

    public void SetValue(FloatVariable replacement)
    {
        value = replacement.value;
    }

    public void ApplyChange(float amount)
    {
        value += amount;
    }

    public void ApplyChange(FloatVariable amount)
    {
        value += amount.value;
    }
}
