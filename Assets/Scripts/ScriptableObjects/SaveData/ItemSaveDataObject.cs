using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSaveDataObject", menuName = "Scriptable Objects/ItemSaveDataObject")]
public class ItemSaveDataObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] items;
    public Dictionary<ItemObject, int> GetId = new Dictionary<ItemObject, int>();
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();
    
    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<ItemObject, int>(); //Making a new dictionary to not duplicate anything
        GetItem = new Dictionary<int, ItemObject>();
        for (int i = 0; i < items.Length; i++)
        {
            GetId.Add(items[i], i); //Give a unique Id to each item
            GetItem.Add(i, items[i]);
        }
    }
    
    public void OnBeforeSerialize()
    {
    }
}
