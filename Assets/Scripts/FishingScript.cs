using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class FishingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Slider Slider;
    public float SpacePressValue;
    public Item item;
    public int ItemValue; // the value on the slider that the item will take - this should have a range of about 3+-;
    private bool IsFishing = false;
    private float Damage;
    void Start()
    {
        SpacePressValue = 5f;
        Slider.value = 0;
        Slider.gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Slider.gameObject.activeSelf) //If fishing minigame is active
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
              Damage = Damage + 1 * Time.deltaTime;
          }

          if(Damage > item.Durability)
            {
                Debug.Log(item.name+" was caught!");
                StopFishing();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartFishing();
        }
    }



    void StartFishing()
    {
        Slider.gameObject.SetActive(true);
        ItemValue = UnityEngine.Random.Range(20, 100);
        IsFishing = true;

        float seconds = ConvertItemRarityToTimerSecs(item.rarity);
        StartCoroutine(FishingTimer(seconds));
    }

    //STOP FISHING SHOULD INCLUDE A PARAMETER FOR IF AN ITEM WAS CAUGHT
    void StopFishing()
    {
        Slider.gameObject.SetActive(false);
        item = null;
        IsFishing = false;
    }


    float ConvertItemRarityToTimerSecs(Item.Rarity rarity)
    {
        float num;
        float RarityValue;
        switch (rarity)
        {
            case (Item.Rarity.Common):

                RarityValue = 20;
                break;


            case (Item.Rarity.Uncommon):
                RarityValue = 15;
                break;


            default:
                Debug.LogWarning("No Item Rarity on item or Rarity Value not specficed!!");
                return 0f;
        }

        num = RarityValue * UnityEngine.Random.Range(1.1f, 1.6f);
        return num;

    }

    public IEnumerator FishingTimer(float seconds)
    {
        Debug.Log("Timer started at "+seconds+" seconds.");
        yield return new WaitForSecondsRealtime(seconds);
        StopFishing();

    }

    //value is the value we are checking , centre is the value of the number and radius is the range of which that number can go
    bool InRange(float value, float centre, float radius)
    {
        return value >= centre - radius && value <= centre + radius;
    }
}
