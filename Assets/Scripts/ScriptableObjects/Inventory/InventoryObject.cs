using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

[CreateAssetMenu(fileName = "InventoryObject", menuName = "Scriptable Objects/InventoryObject")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;
    private ItemSaveDataObject database;
    public List<InventorySlot> container = new List<InventorySlot>();

    private void OnEnable()
    {
        #if UNITY_EDITOR
        database = (ItemSaveDataObject)AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/SaveData/DataBase.asset", typeof(ItemSaveDataObject));
        #else
        database = Resources.Load<ItemSaveDataObject>("DataBase");
        #endif
    }

    public void AddItem(ItemObject _item, int _amount)
    {
        
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == _item)
            {
                container[i].AddAmount(_amount);
                return;
            }
        }
        container.Add(new InventorySlot(database.GetId[_item],_item, _amount)); //Adding to container the item and the amount of it
    }

    public void OnBeforeSerialize()
    { 
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < container.Count; i++)
        {
            container[i].item = database.GetItem[container[i].ID]; //Populate the inventory with the id to obtain the item
        }
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open((string.Concat(Application.persistentDataPath, savePath)), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }
}

[System.Serializable]
public class InventorySlot //Constructor
{
    public int ID;
    public ItemObject item;
    public int amount;

    public InventorySlot(int _id,ItemObject _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}