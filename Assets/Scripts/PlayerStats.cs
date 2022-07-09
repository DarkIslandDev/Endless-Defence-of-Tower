using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Instance

    public static PlayerStats instance;

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
        
    public int Money;
    public int startMoney = 400;

    public int Lives;
    public int startLives = 20;

    public int Rounds;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }
    
}