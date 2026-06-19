using UnityEngine;

public class ScrapButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerInventoryScript playerInvScript;
    public ScrapManager ScrapMan;
    public AudioSource buttonSFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScrapButtonPress()
    {

        foreach(Item item in playerInvScript.Inventory)
        {
            int scrapamount;
            switch (item.rarity)
            {

                case Item.Rarity.Common:
                    scrapamount = UnityEngine.Random.Range(2, 3);
                    break;

                case Item.Rarity.Uncommon:
                    scrapamount = UnityEngine.Random.Range(3, 6);
                    break;

                case Item.Rarity.Rare:
                    scrapamount = UnityEngine.Random.Range(6, 7);
                    break;

                default:
                    Debug.LogWarning("Item Rarity not recognized");
                    scrapamount = 0;
                    break;

            }

            ScrapMan.AddScrap(scrapamount);
            buttonSFX.Play();
        }

        playerInvScript.Inventory.Clear();
        playerInvScript.CurrentWeight = 0;
        
    }
}
