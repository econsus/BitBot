using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item Object", menuName = "Scriptable Objects/Items/Default")]
public class DefaultObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
