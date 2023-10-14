using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class BuildBridge : MonoBehaviour
{
    public TextMeshProUGUI text;
    public NavMeshSurface nmSurface;
    [SerializeField]
    private int cost = 100;
    [SerializeField]
    private GameObject bridge;
    [SerializeField]
    private GameObject river;
    public static Func<int, bool> SpendScore = delegate { return false; };
    private bool isConstructed = false;

    private void Start()
    {
        text.text = cost.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isConstructed)
        {           
            if (other.CompareTag("Player"))
            {
                if (SpendScore(cost))
                {
                    Debug.Log("ear");
                    river.SetActive(false);
                    bridge.SetActive(true);
                    isConstructed = true;
                    text.text = "";
                    nmSurface.BuildNavMesh();

                }
            }
        }
    }
}
