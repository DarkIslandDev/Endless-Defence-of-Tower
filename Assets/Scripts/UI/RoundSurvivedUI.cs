using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class RoundSurvivedUI : MonoBehaviour
{
    public TextMeshProUGUI roundText;

    private void OnEnable()
    {
        StartCoroutine(AmimateText());
    }

    IEnumerator AmimateText()
    {
        roundText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(.7f);

        while (round < PlayerStats.instance.Rounds)
        {
            round++;
            roundText.text = round.ToString();

            yield return new WaitForSeconds(.05f);
        }
    }
}