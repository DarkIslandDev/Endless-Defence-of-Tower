using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class UIManager : MonoBehaviour
{

    #region Instance

    public static UIManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Многовато конечно" + instance.name + " для сцены, найди их все и оставь только один!");
            return;
        }
        instance = this;
    }

    #endregion
    
    public Transform shopButton;
    
    public Transform shopPanel;

    public Transform MainUI;
    public Transform GameOver;

    private void Start()
    {
        MainUI.gameObject.SetActive(true);
        shopPanel.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);
    }

    public void ShopUI()
    {
        shopPanel.gameObject.SetActive(!shopPanel.gameObject.activeSelf);
    }

    public void GameOverUI()
    {
        MainUI.gameObject.SetActive(!MainUI.gameObject.activeSelf);
        GameOver.gameObject.SetActive(!GameOver.gameObject.activeSelf);
    }

    public void RestartUIOnClick()
    {
        // Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void MainMenuUIOnClick()
    {
        //
    }
}