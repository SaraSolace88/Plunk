using System;

using System.Collections;

using System.Collections.Generic;

using UnityEngine;



[CreateAssetMenu(menuName = "AudioProfile")]

public class AudioProfile_SO : ScriptableObject

{

    public List<AudioInfo> audioList;



    public void PlayOneShot(AudioSource aSource, SoundType soundType, float volume)

    {

        foreach (AudioInfo info in audioList)

        {

            if (info.sType == soundType)

            {

                aSource.PlayOneShot(info.clip, volume);

                break;

            }

        }

    }

}

[Serializable]

public struct AudioInfo

{

    public string name;

    public SoundType sType;

    public AudioClip clip;

};