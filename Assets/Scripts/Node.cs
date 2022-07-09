using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color defaultColor;
    public Color hoverColor;

    public Vector3 positionOffset;
    public GameObject structure;
    public StructureItem structureBlueprint;
    public bool isUpgraded = false;
    
    private Renderer rend;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();

        rend.material.color = defaultColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (buildManager.GetStructureToBuild() == null)
        {
            return;
        }
        
        if (structure != null)
        {
            buildManager.SelectedNode(this);
            return;
        }

        if (buildManager.CanBuild)
        {
            return;
        }

        BuildStructure(buildManager.GetStructureToBuild());
    }

    private void BuildStructure(StructureItem blueprint)
    {
        if (PlayerStats.instance.Money < blueprint.Cost)
        {
            return;
        }

        PlayerStats.instance.Money -= blueprint.Cost;

        GameObject building = Instantiate(blueprint.structure, GetBuildPosition(), Quaternion.identity);
        building.transform.SetParent(transform);
        structure = building;

        structureBlueprint = blueprint;

        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void UpgradeStructure()
    {
        if (PlayerStats.instance.Money < structureBlueprint.upgradeCost)
        {
            return;
        }

        if (structureBlueprint.structureLevel == structureBlueprint.maxStructureLevel)
        {
            isUpgraded = true;
            return;
        }

        PlayerStats.instance.Money -= structureBlueprint.upgradeCost;
        
        Destroy(structure);

        for (int i = 0; i < structureBlueprint.structureLevel; i++)
        {
            GameObject building = Instantiate(structureBlueprint.upgradedPrefabs[i], GetBuildPosition(),
                Quaternion.identity);
            structure = building;
            
            GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);
        }
    }

    public void SellStructure()
    {
        PlayerStats.instance.Money += structureBlueprint.GetSellAmount();

        GameObject effect = Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        
        Destroy(structure);
        structureBlueprint = null;
    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = Color.red;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }
}