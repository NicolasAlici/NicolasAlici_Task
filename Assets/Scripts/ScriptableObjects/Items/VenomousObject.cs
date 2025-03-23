using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Venomous Objects", menuName = "Scriptable Objects/Potions Types/Venomous Potion")]
public class VenomousObject : ItemObject
{
    public void Awake()
    {
        itemType = ItemType.Venomous;
    }
}
