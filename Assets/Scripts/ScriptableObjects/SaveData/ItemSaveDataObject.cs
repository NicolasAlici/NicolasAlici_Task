using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSaveDataObject", menuName = "Scriptable Objects/ItemSaveDataObject")]
public class ItemSaveDataObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] items;
    
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();
    
    public void OnAfterDeserialize()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].Id = i;
            GetItem.Add(i, items[i]);
        }
    }
    
    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemObject>();
    }
}
