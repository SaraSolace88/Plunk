using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExit : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
