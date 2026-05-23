using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
public class PlayerInventoryScript : MonoBehaviour
{
    public List<Item> Inventory = new List<Item>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static PlayerInventoryScript instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToInventory(Item item)
    {
        // In case of no item being caught
        if(item == null)
        {
            return;
        }
        if (!Inventory.Contains(item))
        {
            Debug.Log("New Item Added!!");
        }
        Inventory.Add(item);
        
    }
}
