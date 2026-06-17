using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class UpgradeManager : MonoBehaviour
{

    public List<Upgrade> Upgrades;
    public float TractorBeamMult;

    //acts as a clamp on how far the player can go
    public int MaxArea = 1;


    void Start()
    {
        foreach(Upgrade upgrade in Upgrades)
        {
            upgrade.level = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Tractor Beam Stuff
        Upgrade TractorBeamRef = Upgrades.FirstOrDefault(i => i.upgradeName == "Tractor Beam Strength");
        if(TractorBeamRef.level != 0)
        {
            TractorBeamMult = TractorBeamRef.level * 1.005f;
        }
        else
        {
            TractorBeamMult = 0;
        }


        //Area Stuff
        Upgrade AreaRef = Upgrades.FirstOrDefault(i => i.upgradeName == "Unlock Area");
        MaxArea = AreaRef.level;

        MaxArea = Mathf.Clamp(MaxArea, 0, 3);
    }
}
