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
        //in the case no item was caught
        if (item == null)
        {
            return;
        }

       
        //generate item weight and do stuff
        item.Weight = UnityEngine.Random.Range(item.MinWeight, item.MaxWeight);
        item.Weight = (float)Math.Round(item.Weight, 2);
        //in case of item not having enough wieght idk
        if(CurrentWeight + item.Weight > MaxInvWeight)
        {
            //Add error message here
            Debug.LogWarning("Item over Max Inventory Weight!");
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

        //Since this is only updated whenever an item is added the scrap button will need to set curretnweight to zero along with removing all items from inv
        CurrentWeight += item.Weight;

        //This function should be moved to the scrap button when added
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
