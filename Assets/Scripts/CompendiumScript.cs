using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CompendiumScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject CurrentlySelectedIcon;
    public GameObject CurrentlySelectedText;
    public GameObject CurrentlySelecteedDesc;

    private RectTransform Compendium;
    public float LerpSpeed;
    public GameObject FishingSlider;
    Vector2 ClosedPosition = new Vector3(-10,-150);
    Vector2 OpenedPosition = new Vector2(-10, 0f);
    public bool IsOpened;
    void Start()
    {
        Compendium = transform.GetChild(0).gameObject.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {

        if (FishingSlider.activeSelf)
        {
            IsOpened = false;
        }




        if (Input.GetKeyDown(KeyCode.I))
        {
             IsOpened = !IsOpened;          
        }


        if (IsOpened)
        {
            Compendium.anchoredPosition = Vector2.Lerp(Compendium.anchoredPosition, OpenedPosition, LerpSpeed * Time.deltaTime);
        }
        else
        {
            Compendium.anchoredPosition = Vector2.Lerp(Compendium.anchoredPosition, ClosedPosition, LerpSpeed * Time.deltaTime);
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
            
            CurrentlySelectedIcon.GetComponent<Image>().sprite = button.GetComponent<CompButtonScript>().item.Sprite;
            CurrentlySelectedText.GetComponent<TextMeshProUGUI>().text = button.GetComponent<CompButtonScript>().item.name;
            CurrentlySelecteedDesc.GetComponent<TextMeshProUGUI>().text = button.GetComponent<CompButtonScript>().item.Description;
        }
    }


}
