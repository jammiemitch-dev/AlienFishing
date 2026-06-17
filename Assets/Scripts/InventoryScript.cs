using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerInventoryScript PlayerInventoryScript;
    int InventoryCount;
    public TextMeshProUGUI[] texts;
    void Start()
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        InventoryCount = PlayerInventoryScript.Inventory.Count;
        
        texts[1].text = ("Containment Count : " + InventoryCount);
        texts[2].text = ("Cargo Mass : " + PlayerInventoryScript.CurrentWeight + " / " + PlayerInventoryScript.MaxInvWeight);
    }
}
