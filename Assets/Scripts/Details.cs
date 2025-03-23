using System;
using UnityEngine;

public class Details : MonoBehaviour
{
    public string message;

    private void OnMouseEnter()
    {
        DetailManager.instance.ShowDetails(message);
    }
    
    private void OnMouseExit()
    {
        DetailManager.instance.HideDetails();
    }
}
