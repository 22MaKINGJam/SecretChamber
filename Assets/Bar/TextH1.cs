using System.Collections;
using System.Collections.Generic;
using System.Media;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TextH1 : MonoBehaviour
{
    PlayerControl player;


    void Start()
    {
        player = FindObjectOfType<CalH>();
    }
}