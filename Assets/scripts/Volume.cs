using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider volumeGame;

    void Update()
    {
        AudioListener.volume = volumeGame.value;
    }
}
