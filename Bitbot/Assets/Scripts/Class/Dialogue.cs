using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
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
