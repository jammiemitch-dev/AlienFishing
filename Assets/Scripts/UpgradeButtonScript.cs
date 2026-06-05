using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public UpgradeManager upgradeManager;
    public Upgrade upgrade;
    private int ArrayLoc;
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        if (upgradeManager.Upgrades.Contains(upgrade))
        {
            ArrayLoc = FindArrayValue();
            
        }
        else
        {
            UnityEngine.Debug.LogWarning("Unkown upgrade attached to upgrade button , check the upgrade manager");
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        //update text
        int display_level = upgradeManager.Upgrades[ArrayLoc].level + 2;
        text.text = (upgradeManager.Upgrades[ArrayLoc].upgradeName + " " + display_level + ": " + upgradeManager.Upgrades[ArrayLoc].CurrentPrice + " SCRAP");
       
    }



    int FindArrayValue()
    {
        for (int i = 0; i < upgradeManager.Upgrades.Count; i++)
        {
            if (upgradeManager.Upgrades[i] == upgrade)
            {
                
                return i;

            }
        }
        return -1;
    }
}
