using System;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Instance

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("у тебя тут где-то ещё один такой же скрипт. Найди его быстрее и удали к хуям собачим, а может быть лишний скрипт это Я.");
            return;
        }

        instance = this;
    }

    #endregion

    public GameObject buildEffect;
    public GameObject sellEffect;

    public StructureItem structureToBuild;  //   стоит в слоте для постройки
    private Node selectedNode;
    public NodeUI nodeUI;
    
    public bool CanBuild { get { return structureToBuild != null;}}
    public bool HasMoney { get { return PlayerStats.instance.Money > structureToBuild.Cost;}}
    public void SelectedNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        structureToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectStructureToBuild(StructureItem structure)
    {
        structureToBuild = structure;
        DeselectNode();
    }

    public StructureItem GetStructureToBuild()
    {
        return structureToBuild;
    }
}