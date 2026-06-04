using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class UpgradeManager : MonoBehaviour
{

    public List<Upgrade> Upgrades;
    public float TractorBeamMult;
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
        Upgrade TractorBeamRef = Upgrades.FirstOrDefault(i => i.upgradeName == "Tractor Beam Strength");
        if(TractorBeamRef.level != 0)
        {
            TractorBeamMult = TractorBeamRef.level * 1.005f;
            Debug.Log(TractorBeamRef.level);
        }
        else
        {
            TractorBeamMult = 0;
        }
    }
}
