using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public TextMeshProUGUI upgradeCost;
    public Button upgradeButton;

    public TextMeshProUGUI sellAmount;

    private Node target;

    public void SetTarget(Node tar)
    {
        target = tar;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "Upgrade cost: " + target.structureBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "Sell cost: " + target.structureBlueprint.GetSellAmount();
        
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeStructure();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellStructure();
        BuildManager.instance.DeselectNode();
    }
}