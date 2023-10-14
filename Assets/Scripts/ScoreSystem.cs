using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI score;

    public int currentScore;
    private void OnEnable()
    {
        HealthSystem.UpdateScore += UpdateScore;
        BuildBridge.SpendScore += SpendScore;

    }

    private void OnDisable()
    {
        HealthSystem.UpdateScore -= UpdateScore;
        BuildBridge.SpendScore -= SpendScore;
    }
    private void UpdateScore(int incommingScore)
    {
        currentScore += incommingScore;
        score.text = currentScore.ToString();
    }

    private Boolean SpendScore(int incommingScore)
    {
        if (currentScore >= incommingScore)
        {
            currentScore -= incommingScore;
            score.text = currentScore.ToString();
            return true;
        }
        return false;
    }
}
