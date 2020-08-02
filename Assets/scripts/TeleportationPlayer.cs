using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportationPlayer : MonoBehaviour
{
    public ScreenFader screenFader;

    public void OnTriggerEnter()
    {
        Texture2D nullTexture = new Texture2D(1, 1) as Texture2D;
        nullTexture.SetPixel(0, 0, Color.white);
        nullTexture.Apply();
        screenFader.colorTexture = nullTexture;
        screenFader.fadeColor = Color.white;
        screenFader.fadeSpeed = 0.9f;
        screenFader.fadeState = ScreenFader.FadeState.In;
        Invoke("LoadScene", 1 / screenFader.fadeSpeed);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("chapter_1", LoadSceneMode.Single);
    }


}
