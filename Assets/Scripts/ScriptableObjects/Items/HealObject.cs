using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal Objects", menuName = "Scriptable Objects/Potions Types/Heal Potion")]
public class HealObject : ItemObject
{
    public float restoreHealthValue;
    private void Awake()
    {
        itemType = ItemType.Heal;
    }
}
