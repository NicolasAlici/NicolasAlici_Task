using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeAdd Objects", menuName = "Scriptable Objects/Potions Types/TimeAdd Potion")]
public class TimeAdd : ItemObject
{
    public float timeAddValue;

    private void Awake()
    {
        itemType = ItemType.TimeAdding;
    }
}
