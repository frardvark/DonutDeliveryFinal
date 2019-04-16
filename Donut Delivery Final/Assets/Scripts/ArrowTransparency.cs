using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTransparency : MonoBehaviour
{
    public Color color = Color.white;

    void Start()
    {
        color.a = 0f;
    }
}
