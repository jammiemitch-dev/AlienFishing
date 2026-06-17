using UnityEngine;
using System.Collections.Generic;
public class ShopScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ScrapManager ScrapManager;


    public List<Upgrade> Upgrades;
    

    void Start()
    {
    }




    public void OnShopButtonClick(UpgradeButtonScript buttonscript)
    {
        Upgrade upgrade = buttonscript.upgrade;
        if(upgrade.level >= upgrade.LevelCap)
        {
            return;
        }

       if(ScrapManager.Scrap >= upgrade.CurrentPrice)
        {
            ScrapManager.AddScrap(-upgrade.CurrentPrice);
            upgrade.LevelUp();
        }
    }
    
}
