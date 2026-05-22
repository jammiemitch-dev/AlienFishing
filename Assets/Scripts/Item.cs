using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public string Description;
    public Sprite Sprite;
    //This defines all the rarity types
    public enum Rarity {
        Common,
        Uncommon,
        Rare,
    }
    //this is the rairty of the object created
    public Rarity rarity;
    public float Durability;
}
