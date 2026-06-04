using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using System;
public class AreaScript : MonoBehaviour
{
    public enum Areas { 
    
        Farmlands,
        Ocean,
        City,
        Artic,

    }

    public Areas CurrentArea;
    public Item[] CurrentItemPool;
  
    public Item[] FarmLand_ItemPool;
    public Item[] Ocean_ItemPool;
    public Item[] City_ItemPool;
    public Item[] Artic_ItemPool;



    //All the stuff other than area defs
    private TextMeshProUGUI AreaText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AreaText = GameObject.Find("AreaUI").GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        AreaText.text = Convert.ToString(CurrentArea);


        //Switches ItemPool Depending corrosponding with Area
        switch (CurrentArea)
        {

            case (Areas.Farmlands):
                CurrentItemPool = FarmLand_ItemPool;
                break;

            case (Areas.Ocean):
                CurrentItemPool = Ocean_ItemPool;
                break;

            case (Areas.City):
                CurrentItemPool = City_ItemPool;
                break;

            case (Areas.Artic):
                CurrentItemPool = Artic_ItemPool;
                break;



            default:
                Debug.LogWarning("Unrecognized Area - Unable to assign ItemPool");
                break;

        }

    }
}
