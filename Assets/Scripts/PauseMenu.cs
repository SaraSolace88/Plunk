using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    private Controls pInput;
    private bool mOpen;

    public static Action FadeIn = delegate { };
    public static Action FadeOut = delegate { };

    private void Start()
    {
        pInput = new Controls();
        pInput.Enable();
        pInput.Player.Pause.performed += PauseMenuOpen;
    }

    private void PauseMenuOpen(InputAction.CallbackContext c)
    {
        if (!mOpen)
        {
            FadeOut();
            menu.SetActive(true);
            mOpen = true;
        }
        else
        {
            FadeIn();
            menu.SetActive(false);
            mOpen = false;
        }
    }

    private void OnDisable()
    {
        pInput.Disable();
    }

}
