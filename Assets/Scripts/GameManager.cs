using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using System;



public class GameManager : MonoBehaviour

{

    public static Action<SoundType> DelPlayOneShot = delegate { };

    public static void PlayOneShot(SoundType sType)

    {

        DelPlayOneShot(sType);

    }



    private void Awake()

    {

        DontDestroyOnLoad(gameObject);

    }

}

public enum SoundType { Fire, Fire2, Explode, Powerup, Death, Laser }
