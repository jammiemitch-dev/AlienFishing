using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSliderScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slider ParentSlider;
    private Slider slider;
    private GameObject player;
    public float SavedSliderValue;

    void Start()
    {
        slider = GetComponent<Slider>();
        ParentSlider = GetComponentInParent<Slider>();
        player = GameObject.Find("Player");
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ParentSlider.gameObject.activeSelf)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            slider.value = SavedSliderValue;
        }

        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
       
        if(SavedSliderValue != player.GetComponent<FishingScript>().ItemValue)
        {
            SavedSliderValue = Mathf.Lerp(SavedSliderValue, player.GetComponent<FishingScript>().ItemValue, 2 * Time.deltaTime);
        }
    }
}
