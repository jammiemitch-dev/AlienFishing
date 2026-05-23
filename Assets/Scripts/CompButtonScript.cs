using UnityEngine;
using UnityEngine.UI;

public class CompButtonScript : MonoBehaviour
{
    public Item item;
    private Image[] images;
    public bool IsClickable = false;
    void Start()
    {
        images = GetComponentsInChildren<Image>();
        images[1].sprite = item.Sprite;
    }

    // Update is called once per frame
    void Update()
    {
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
}
