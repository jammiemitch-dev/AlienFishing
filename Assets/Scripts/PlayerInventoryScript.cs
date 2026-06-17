using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
public class PlayerInventoryScript : MonoBehaviour
{
    public List<Item> Inventory = new List<Item>();
    public float MaxInvWeight = 30f;
    public float CurrentWeight;
    public GameObject ItemShowCase;
    public GameObject GameManager;
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

        //Forgot to generate the item's weight lmao
        item.Weight = UnityEngine.Random.Range(item.MinWeight, item.MaxWeight);
        item.Weight = (float)Math.Round(item.Weight, 2);




        //CASES ----------------------------------------------------------
        // In case of no item being caught
        if (item == null)
        {
            return;
        }

        //in case of item not having enough wieght idk
        if(CurrentWeight + item.Weight > MaxInvWeight)
        {
            //Add error message here
            Debug.LogWarning("Item over Max Inventory Weight!");
            return;
        }
        //----------------------------------------------------------------

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

        CurrentWeight += item.Weight;
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
