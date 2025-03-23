using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public InventoryObject inventory;
    
    public void SaveGame()
    {
        inventory.Save();
    }

    public void LoadGame()
    {
        inventory.Load();
        SceneManager.LoadScene("Game");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ClearInventory()
    {
        inventory.Clear();
        
    }

    public void GoGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        
    }
    
}
