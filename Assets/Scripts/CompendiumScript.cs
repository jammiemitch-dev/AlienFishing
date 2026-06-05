using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CompendiumScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image CurrentlySelectedIcon;
    public TextMeshProUGUI CurrentlySelectedText;
    public TextMeshProUGUI CurrentlySelecteedDesc;



    // Update is called once per frame

    private void LateUpdate()
    {
        if (CurrentlySelectedIcon.sprite == null)
        {
            //make transparent
            CurrentlySelectedIcon.color = new Color(CurrentlySelectedIcon.color.r, CurrentlySelectedIcon.color.g, CurrentlySelectedIcon.color.b, 0f);
        }
        else
        {
            CurrentlySelectedIcon.color = new Color(CurrentlySelectedIcon.color.r, CurrentlySelectedIcon.color.g, CurrentlySelectedIcon.color.b, 1f);
        }
    }
    public void OnCompendiumButtonPress(GameObject button)
    {

        if (!button.GetComponent<CompButtonScript>())
        {
            Debug.LogWarning("Compendium Button has no attached script!");
        }

        if(button.GetComponent<CompButtonScript>().IsClickable == false)
        {
            return;
        }
        else
        {
            
            CurrentlySelectedIcon.sprite = button.GetComponent<CompButtonScript>().item.Sprite;
            CurrentlySelectedText.text = button.GetComponent<CompButtonScript>().item.name;
            CurrentlySelecteedDesc.text = button.GetComponent<CompButtonScript>().item.Description;
        }
    }


}
