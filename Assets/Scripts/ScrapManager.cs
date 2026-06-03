using TMPro;
using UnityEngine;

public class ScrapManager : MonoBehaviour
{
    public int Scrap;
    public TextMeshProUGUI ScrapText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ScrapManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScrapText.text = ("Scrap: " + Scrap);
    }


    public void AddScrap(int amount)
    {
        //check for if amount is 
        if (Scrap + amount < 0)
            return;

        Scrap += amount;
    }
}
