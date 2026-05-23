using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompendiumScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject CurrentlySelectedIcon;
    public GameObject CurrentlySelectedText;
    public GameObject CurrentlySelecteedDesc;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnCompendiumButtonPress(GameObject button)
    {
        if (!button.GetComponent<CompButtonScript>())
        {
            Debug.LogWarning("Compendium Button has no attached script!");
        }

        else
        {
            CurrentlySelectedIcon.GetComponent<Image>().sprite = button.GetComponent<CompButtonScript>().item.Sprite;
            CurrentlySelectedText.GetComponent<TextMeshProUGUI>().text = button.GetComponent<CompButtonScript>().item.name;
            CurrentlySelecteedDesc.GetComponent<TextMeshProUGUI>().text = button.GetComponent<CompButtonScript>().item.Description;
        }
    }
}
