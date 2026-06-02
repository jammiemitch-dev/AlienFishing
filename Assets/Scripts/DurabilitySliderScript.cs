using UnityEngine;
using UnityEngine.UIElements;

public class DurabilitySliderScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private UnityEngine.UI.Slider slider;
    private FishingScript fishingscript;
    void Start()
    {
        slider = GetComponent<UnityEngine.UI.Slider>();
        fishingscript = GameObject.Find("Player").GetComponent<FishingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = fishingscript.item.Durability;
        slider.value = fishingscript.Damage;
    }


    

}
