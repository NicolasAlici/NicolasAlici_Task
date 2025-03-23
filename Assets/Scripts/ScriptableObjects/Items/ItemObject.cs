using UnityEngine;

public enum ItemType
{
    Venomous,
    Heal,
    TimeAdding
}

[CreateAssetMenu(fileName = "ItemObject", menuName = "Scriptable Objects/ItemObject")]
public abstract class ItemObject : ScriptableObject
{
    public GameObject itemPrefab;
    public ItemType itemType;
    [TextArea(15, 20)]
    public string description;
}
