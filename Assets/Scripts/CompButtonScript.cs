using UnityEngine;
using UnityEngine.UI;

public class CompButtonScript : MonoBehaviour
{
    public Item item;
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerInventoryScript.instance.Inventory.Contains(item))
        {
            image.color = Color.black;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
