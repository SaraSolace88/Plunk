using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer mRen;

    [SerializeField]
    private Color newColor;
    private void Start()
    {
        mRen.material.color = newColor;
    }
}
