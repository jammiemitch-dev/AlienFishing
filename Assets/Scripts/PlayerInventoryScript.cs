using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using System;
using Unity.Mathematics;
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



        //give scrap dependent on item rarity
        int scrapamount;
        switch (item.rarity)
        {

            case Item.Rarity.Common:
                scrapamount = UnityEngine.Random.Range(2, 3);
                break;

            case Item.Rarity.Uncommon:
                scrapamount = UnityEngine.Random.Range(3, 6);
                break;

            case Item.Rarity.Rare:
                scrapamount = UnityEngine.Random.Range(6, 7);
                break;

            default:
                Debug.LogWarning("Item Rarity not recognized");
                scrapamount = 0;
                break;



        }


        GameManager.GetComponent<ScrapManager>().AddScrap(scrapamount);
        ItemShowCase.GetComponent<ItemShowCaseScript>().SetValues(item);
        ItemShowCase.SetActive(true);
        if (!Inventory.Contains(item))
        {
            Debug.Log("New Item Added!!");
        }

            Inventory.Add(item);
        
    }
}
