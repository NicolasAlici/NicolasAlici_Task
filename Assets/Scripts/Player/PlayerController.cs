using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public InventoryObject inventory;
    
    //Serialized Vars
    [SerializeField] private int moveSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float minHealth;
    [SerializeField] private Image healthBar;
    //Private Vars
    private Rigidbody2D _rb;
    private Vector2 _moveDir;
    private float _currentHealth;

    private void Start()
    {
        _rb =   GetComponent<Rigidbody2D>();
        SetHealth();
    }
    
    private void Update()
    {
        _rb.linearVelocity = _moveDir * moveSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            inventory.Load();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _moveDir = context.ReadValue<Vector2>();
    }

    private void SetHealth()
    {
        _currentHealth = minHealth;
        healthBar.fillAmount = _currentHealth;
    }

    public void HealUp(float amount)
    {
        _currentHealth += amount;
        healthBar.fillAmount = _currentHealth / maxHealth;
        if (_currentHealth > maxHealth)
        {
            _currentHealth = minHealth;
            //Win Event
        }
    }
}
