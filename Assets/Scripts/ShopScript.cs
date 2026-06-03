using UnityEngine;

public class ShopScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int Scrap;
    public bool IsOpened;
    public float LerpSpeed;
    public GameObject Compendium;
    public GameObject FishingSlider;
    private RectTransform ShopRect;

    Vector2 ClosedPosition = new Vector3(660,0);
    Vector2 OpenedPosition = new Vector2(0, 0f);

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


    
}
