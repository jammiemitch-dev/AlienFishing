using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Upgrade")]
public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public float basePrice = 10f;
    public float priceMultiplier = 1.5f;
    public int LevelCap;
    [HideInInspector] public int level = 0;

    public float CurrentPrice => basePrice * Mathf.Pow(priceMultiplier, level);

    public void LevelUp()
    {
        level++;
    }
}