using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Transform effectHolder;

    private bool gameEnded = false;
    
    private void Start()
    {
        effectHolder = transform;
    }

    private void Update()
    {
        if (gameEnded)
        {
            return;
        }
        
        if (PlayerStats.instance.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        UIManager.instance.GameOverUI();
        Time.timeScale = 0;
    }
}