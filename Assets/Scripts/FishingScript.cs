using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class FishingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Slider Slider;
    public float SpacePressValue;
    public Item item;
    public int ItemValue; // the value on the slider that the item will take - this should have a range of about 3+-;
    private bool IsFishing = false;
    public float Damage;
    public float DamageMultiplier;
    public GameObject TractorBeam;
    public AreaScript AreaScript;
    private Coroutine IsValNull;



    public UpgradeManager upgradeManager;

    //Each Area should have its own itempool , this is just for testing
    public Item[] ItemPool;
    void Start()
    {
        IsValNull = null;
        SpacePressValue = 5f;
        Slider.value = 0;
        Slider.gameObject.SetActive(false);
        TractorBeam.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(upgradeManager.TractorBeamMult != 0)
        {
            DamageMultiplier = upgradeManager.TractorBeamMult;
        }
        else
        {
            DamageMultiplier = 1;
        }




        if (Slider.gameObject.activeSelf) //If fishing minigame is active
        {

            Slider.value -= 20 * Time.deltaTime;






            // if space key is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Slider.value += SpacePressValue;
            }
            //-------------------------------;



            if (InRange(Slider.value, ItemValue, 5))
            {
                Damage += DamageMultiplier + 1 * Time.deltaTime;
                TractorBeam.SetActive(true);
            }
            else
            {
                TractorBeam.SetActive(false);
            }



            if (Damage > item.Durability)
            {
                Debug.Log(item.name + " was caught!");
                StopFishing(item);
            }
        }



        //Random ItemVal Change

        if (IsValNull == null)
        {
            IsValNull = StartCoroutine(CheckForItemSliderChange(1));
        }



        if (Input.GetKeyDown(KeyCode.Tab) && !IsFishing)
        {
            StartFishing();
        }
    }



    void StartFishing()
    {
        ItemPool = AreaScript.CurrentItemPool;
        item = ItemPool[UnityEngine.Random.Range(0,ItemPool.Length)];
        Slider.gameObject.SetActive(true);
        ItemValue = UnityEngine.Random.Range(20, 100);
        IsFishing = true;
        Damage = 0;
        Slider.value = 0;
        Slider.gameObject.GetComponentInChildren<ItemSliderScript>().SavedSliderValue = ItemValue;

        float seconds = ConvertItemRarityToTimerSecs(item.rarity);
        StartCoroutine(FishingTimer(seconds));
        
    }

    //STOP FISHING SHOULD INCLUDE A PARAMETER FOR IF AN ITEM WAS CAUGHT
    void StopFishing(Item? item)
    {
        Slider.gameObject.SetActive(false);
        PlayerInventoryScript.instance.AddItemToInventory(item);
        IsFishing = false;
        TractorBeam.SetActive(false);
        Damage = 0;
        Slider.value = 0;
        IsValNull = null;
        StopAllCoroutines();
    }


    float ConvertItemRarityToTimerSecs(Item.Rarity rarity)
    {
        float num;
        float RarityValue;
        switch (rarity)
        {
            case (Item.Rarity.Common):

                RarityValue = 13;
                break;


            case (Item.Rarity.Uncommon):
                RarityValue = 10;
                break;

            case (Item.Rarity.Rare):
                RarityValue = 9;
                break;


            default:
                Debug.LogWarning("No Item Rarity on item or Rarity Value not specficed!!");
                return 0f;
        }

        num = RarityValue * UnityEngine.Random.Range(1.1f, 1.6f);
        num = Mathf.Clamp(num,5f, 1000f);
        return num;

    }

    public IEnumerator FishingTimer(float seconds)
    {
        Debug.Log("Timer started at "+seconds+" seconds.");
        yield return new WaitForSecondsRealtime(seconds);
        StopFishing(null);

    }

    //value is the value we are checking , centre is the value of the number and radius is the range of which that number can go
    bool InRange(float value, float centre, float radius)
    {
        return value >= centre - radius && value <= centre + radius;
    }


    int ChangeItemSliderValue()
    {
        float CurrentVal = ItemValue;
        float ItemRarityVal = ConvertItemRarityToTimerSecs(item.rarity);
        float NewSliderValue;
        if (CurrentVal <= 20)
        {
            NewSliderValue = CurrentVal * UnityEngine.Random.Range(1f, 1.3f) + ItemRarityVal * 1.3f;
        }
        else
        {
            NewSliderValue = CurrentVal * UnityEngine.Random.Range(-1f, 1f) + ItemRarityVal * 1.3f;
        }

        NewSliderValue = Mathf.Clamp(NewSliderValue, 0, 100);

        return Convert.ToInt32(NewSliderValue);

    }



    public IEnumerator CheckForItemSliderChange(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);

        int chance = UnityEngine.Random.Range(0, 4); // 20% chance
        if (chance == 1)
        {
            ItemValue = ChangeItemSliderValue();
        }

        IsValNull = null;
    }
}
