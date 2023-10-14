using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Image))]
public class ScreenFader : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private Image screenFade;

    private float rate;
    private bool bFadeIn, bFading;

    private Color black = new Color(0, 0, 0, 1);
    private Color clear = new Color(0, 0, 0, 0);

    private void OnEnable()
    {
        PauseMenu.FadeIn += FadeIn;
        PauseMenu.FadeOut += FadeOut;
    }

    private void OnDisable()
    {
        PauseMenu.FadeIn -= FadeIn;
        PauseMenu.FadeOut -= FadeOut;
    }
    private void Awake()
    {
        Time.timeScale = 1;
        screenFade = GetComponent<Image>();
    }

    private void Update()
    {
        
    }

    private void FadeIn()
    {
        if(bFading) return; //prevents calling fader when already active
        bFadeIn = true;
        bFading = true;
        StartCoroutine(nameof(Fader));
    }

    private void FadeOut()
    {
        if (bFading) return; //prevents calling fader when already active
        bFadeIn = false;
        bFading = true;
        StartCoroutine(nameof(Fader));
    }
    IEnumerator Fader()
    {
        while (bFading)
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            yield return new WaitForEndOfFrame();
            rate += Time.deltaTime * speed;


            //transitions either in or out
            if (bFadeIn)
            {
                screenFade.color = Color.Lerp(black, clear, rate);
            }
            else
            {
                screenFade.color = Color.Lerp(clear, black, rate);
            }
            //exits loop when desired state is reached
            if(rate >= 1)
            {
                if(bFadeIn)
                {
                    FadeOut();
                }
                else
                {
                    FadeIn();
                }
                bFading = false;
                rate = 0;

                if (!bFading)
                {
                    if (bFadeIn)
                    {
                        Time.timeScale = 1;
                    }
                    else
                    {
                        Time.timeScale = 0;
                    }
                }
            }
        }
    }
}

