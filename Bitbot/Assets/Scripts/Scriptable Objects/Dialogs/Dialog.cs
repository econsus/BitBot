using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Scriptable Objects/Dialog System/Dialog")]
public class Dialog : ScriptableObject
{
    public Character character;
    public Sentence[] sentences;
}

[System.Serializable]
public struct Sentence
{
    public Character speaker;

    [TextArea(2, 3)]
    public string sentence;
}
