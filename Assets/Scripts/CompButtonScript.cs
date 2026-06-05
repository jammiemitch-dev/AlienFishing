using UnityEngine;
using UnityEngine.UI;

public class CompButtonScript : MonoBehaviour
{
    public Sprite NullSprite;
    public Item item;
    private Image[] images;
    public bool IsClickable = false;
    void Start()
    {
        images = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (item != null)
        {


            images[1].sprite = item.Sprite;
            if (!PlayerInventoryScript.instance.Inventory.Contains(item))
            {
                images[1].color = Color.black;
                IsClickable = false;
            }
            else
            {
                images[1].color = Color.white;
                IsClickable = true;
            }
        }

        else
        {
            images[1].sprite = NullSprite;
            images[1].color = Color.white;
        }
    }
}
