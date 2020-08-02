using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public AudioSource sound;
    void Start()
    {
        sound.volume = Menu.volumeSound;
        Screen.fullScreen = Menu.isFullScreen;
    }
}
