using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI score;

    private int currentScore;
    private void OnEnable()
    {
        HealthSystem.UpdateScore += UpdateScore;
    }

    private void OnDisable()
    {
        HealthSystem.UpdateScore -= UpdateScore;
    }
    private void UpdateScore(int incommingScore)
    {
        currentScore += incommingScore;
        score.text = currentScore.ToString();
    }
}
