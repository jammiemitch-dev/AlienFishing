using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using System;
using UnityEditor.ShaderKeywordFilter;
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
    public GameObject ButtonParent;
    private UpgradeManager upgradeManager;

    private void Awake()
    {
        upgradeManager = gameObject.GetComponent<UpgradeManager>();
        RefreshCompendiumItems();
    }

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

        RefreshCompendiumItems();

    }





    public void RefreshCompendiumItems()
    {

        CompButtonScript[] list = ButtonParent.GetComponentsInChildren<CompButtonScript>();

        for(int i = 0; i < CurrentItemPool.Length; i++)
        {
            list[i].item = CurrentItemPool[i];
        }
        //iterate over "leftovers" aka anything not touched by the first for loop
        for (int i = CurrentItemPool.Length; i < list.Length; i++)
        {
            list[i].item = null;
        }

    }


    public void AreaButtonPressed(GameObject button)
    {
        if (button.name.Contains("+") && CurrentArea!=Areas.Artic)
        {
            int value = (int)CurrentArea;
            if(value < upgradeManager.MaxArea)
            {
                CurrentArea++;
            }
        }
        else if (button.name.Contains("-") && CurrentArea!=Areas.Farmlands)
        {
            CurrentArea--;
        }
    }
}
