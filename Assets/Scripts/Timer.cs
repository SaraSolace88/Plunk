using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timer;
    public int minutes = 0;
    public int seconds = 0;
    private bool timerActive = false;

    public static Action UpdateMinutes = delegate { };

    private void Update()
    {
        if (!timerActive)
        {
            StartCoroutine(nameof(addSecond));
        }
    }

    IEnumerator addSecond()
    {
        timerActive = true;
        yield return new WaitForSeconds(1);
        seconds++;
        if(seconds == 60)
        {
            minutes++;
            UpdateMinutes();
            seconds = 0;
        }
        if (seconds < 10)
        {
            timer.text = minutes.ToString() + ":" + 0 + seconds.ToString();
        }
        else
        {
            timer.text = minutes.ToString() + ":" + seconds.ToString();
        }
        //wait for second then add 1 t seconds, if seconds = 60 make another minute.
        //then update text timer
        timerActive = false;
    }
}
