using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Items/Building")]
public class StructureItem : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public GameObject structure;
    public int Cost;

    public int structureLevel = 1;
    public int maxStructureLevel = 5;
    public GameObject[] upgradedPrefabs;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return Cost = Cost + ((Cost * 75) / 100);   //  процент = 75
    }
}