using UnityEngine;
using System.Collections.Generic;
public class ShopScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ScrapManager ScrapManager;
    public bool IsOpened;
    public float LerpSpeed;
    public GameObject Compendium;
    public GameObject FishingSlider;
    private RectTransform ShopRect;
    Vector2 ClosedPosition = new Vector3(660,0);
    Vector2 OpenedPosition = new Vector2(0, 0f);

    public List<Upgrade> Upgrades;
    

    void Start()
    {
        ShopRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (FishingSlider.activeSelf)
        {
            IsOpened = false;
            LerpSpeed = 6f;
        }
        else
        {
            LerpSpeed = 3f;
        }


        if (Input.GetKeyDown(KeyCode.O))
        {
            IsOpened = !IsOpened;
        }


        if (IsOpened)
        {
            ShopRect.anchoredPosition = Vector2.Lerp(ShopRect.anchoredPosition, OpenedPosition, LerpSpeed * Time.deltaTime);
        }
        else
        {
            ShopRect.anchoredPosition = Vector2.Lerp(ShopRect.anchoredPosition, ClosedPosition, LerpSpeed * Time.deltaTime);
        }





    }


    public void OnShopButtonClick(UpgradeButtonScript buttonscript)
    {
        Upgrade upgrade = buttonscript.upgrade;


       if(ScrapManager.Scrap >= upgrade.CurrentPrice)
        {
            ScrapManager.AddScrap(-upgrade.CurrentPrice);
            upgrade.LevelUp();
        }
    }
    
}
