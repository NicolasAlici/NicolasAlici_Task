using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundItem : MonoBehaviour
{
    public ItemObject item;
    
    public virtual void Use() {}
}
