using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum PurchasingState
{
    Locked,
    Unlocked
}
public class ShopItem : MonoBehaviour
{
    public PurchasingState state;
    public StructureItem item;

    public Image icon;
    public TextMeshProUGUI Name;
    public Button purchaseButton;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;

        icon = transform.GetChild(0).GetComponent<Image>();
        Name = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        purchaseButton = transform.GetChild(2).GetComponent<Button>();

        icon.sprite = item.Icon;
        Name.text = item.Name;
        TextMeshProUGUI cost = purchaseButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        cost.text = item.Cost.ToString();

        purchaseButton.onClick.AddListener(PurchaseOnClick);
    }

    public void PurchaseOnClick()
    {
        buildManager.structureToBuild = item;
        buildManager.SelectStructureToBuild(buildManager.structureToBuild);
        UIManager.instance.ShopUI();
    }
}