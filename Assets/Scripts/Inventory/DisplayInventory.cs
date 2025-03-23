using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory; //Inventory to display

    public int X_SPACE_BETWEEN_SLOTS;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_SLOTS;
    public int X_START;
    public int Y_START;
    
    
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    private void Start()
    {
        CreateDisplay();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++) //Create display
        {
            var obj = Instantiate(inventory.container[i].item.itemPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.container[i], obj); //Add the item created to dictionary
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++) //Update Display
        {
            if (itemsDisplayed.ContainsKey(inventory.container[i])) //Is already in Inventory?
            {
                itemsDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0"); //If is inside, update the amount
            }
            else //If not create the object inside the inventory
            {
                var obj = Instantiate(inventory.container[i].item.itemPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.container[i], obj); //Add the item created to dictionary
            }
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_SLOTS * (i % NUMBER_OF_COLUMN)), Y_START + ((-Y_SPACE_BETWEEN_SLOTS * (i/NUMBER_OF_COLUMN))), 0f);
    }
}
