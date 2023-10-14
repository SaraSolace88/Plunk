using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : GameAction
{
    public override void Action()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
