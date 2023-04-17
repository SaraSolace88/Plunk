using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;

    private void OnEnable()
    {
        HealthSystem.UpdateHealthBar += UpdateHealthBar;
    }

    private void OnDisable()
    {
        HealthSystem.UpdateHealthBar -= UpdateHealthBar;
    }
    private void UpdateHealthBar(float amount)
    {
        healthBar.fillAmount = amount;   
    }
}
