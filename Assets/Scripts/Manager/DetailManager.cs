using System;
using UnityEngine;
using TMPro;

public class DetailManager : MonoBehaviour
{
    public static DetailManager instance;
    
    public TextMeshProUGUI detailsText;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void ShowDetails(string message)
    {
        gameObject.SetActive(true);
        detailsText.text = message;
    }

    public void HideDetails()
    {
        gameObject.SetActive(false);
        detailsText.text = string.Empty;
    }
}
