using UnityEngine;

[CreateAssetMenu(fileName ="New Character", menuName = "Scriptable Objects/Dialogue System/Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public Sprite characterPortrait;
}
