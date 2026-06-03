using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
