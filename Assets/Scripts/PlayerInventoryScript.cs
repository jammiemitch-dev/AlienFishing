using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using System;
public class PlayerInventoryScript : MonoBehaviour
{
    public List<Item> Inventory = new List<Item>();
    public GameObject ItemShowCase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject GameManager;

    public Item TestItem;
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
        if (Input.GetKeyDown(KeyCode.V))
        {
            AddItemToInventory(TestItem);
        }
    }

    public void AddItemToInventory(Item item)
    {
        // In case of no item being caught
        if(item == null)
        {
            return;
        }

        int intamount = Convert.ToInt32(item.Durability);

        GameManager.GetComponent<ScrapManager>().AddScrap(intamount);
        ItemShowCase.GetComponent<ItemShowCaseScript>().SetValues(item);
        ItemShowCase.SetActive(true);
        if (!Inventory.Contains(item))
        {
            Debug.Log("New Item Added!!");
        }

            Inventory.Add(item);
        
    }
}
