using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private bool bPlayer;
    [SerializeField] 
    private bool bBoss;
    [SerializeField]
    private int score;
    [SerializeField]
    private int maxHealth = 10;
    [SerializeField]
    private GameActionSequence deathSequence;

    [SerializeField]
    private Image healthBar;

    public int currentHealth;
    private bool bAlive = true;

    public bool isAlive => bAlive;

    public static Action<float> UpdateHealthBar = delegate { };
    public static Action<int> UpdateScore = delegate { };
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0 , maxHealth);

        //talk to healthbar
        if (bPlayer)
            UpdateHealthBar(currentHealth / (maxHealth * 1f)); //Player       

        if (currentHealth == 0 && bAlive)
        {
            bAlive = false;
            MegaDeath();
        }
    }

    private void MegaDeath()
    {
        if (bPlayer)
        {
            Debug.Log("he dead");
            deathSequence.Play();            
        }
        else if (bBoss)
        {
            UpdateScore(score);
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            UpdateScore(score);
            Destroy(gameObject);
        }
    }
}
