using System.Collections;

using System.Collections.Generic;

using UnityEngine;



[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour

{

    [SerializeField]

    private float mainVolume = 1;

    [SerializeField]

    private AudioSource aSource;

    [SerializeField]

    private AudioProfile_SO aProfile;

    private void OnEnable()

    {

        GameManager.DelPlayOneShot += PlayOneShot;

    }

    private void OnDisable()

    {

        GameManager.DelPlayOneShot -= PlayOneShot;

    }

    private void PlayOneShot(SoundType sType)

    {

        aProfile.PlayOneShot(aSource, sType, mainVolume);

    }

}
