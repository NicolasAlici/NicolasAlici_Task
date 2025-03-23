using System;
using UnityEngine;

public class HealthPotion : GroundItem
{
    public HealObject _healObject;
    
    public override void Use()
    {
        PlayerController playerController = GameObject.FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.HealUp(_healObject.restoreHealthValue);
        }
    }
}
