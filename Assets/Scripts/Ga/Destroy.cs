using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroy : GameAction
{
    [SerializeField]
    private PlayerMovement pMovement;
    MeshRenderer mRenderer;
    public GameObject gun;
    public override void Action()
    {
        mRenderer = GetComponentInChildren<MeshRenderer>();
        mRenderer.enabled = false;
        gun.SetActive(false);
        pMovement.enabled = false;
    }
}
