using System;
using UnityEngine;
using  TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI lives;

    private void Update()
    {
        lives = GetComponent<TextMeshProUGUI>();
        lives.text = PlayerStats.instance.Lives + " Lives";
    }
}