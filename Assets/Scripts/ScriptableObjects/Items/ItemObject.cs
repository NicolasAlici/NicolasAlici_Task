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
    public int Id;
    public Sprite UIdisplay;
    public ItemType itemType;
    [TextArea(15, 20)]
    public string description;
    
    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id;

    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.Id;
    }
}