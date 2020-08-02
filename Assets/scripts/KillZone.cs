using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    public ScreenFader screenFader;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Texture2D nullTexture = new Texture2D(1, 1) as Texture2D;
            nullTexture.SetPixel(0, 0, Color.black);
            nullTexture.Apply();
            screenFader.colorTexture = nullTexture;
            screenFader.fadeColor = Color.black;
            screenFader.fadeSpeed = 0.9f;
            screenFader.fadeState = ScreenFader.FadeState.In;
            Invoke("LoadScene", 1 / screenFader.fadeSpeed);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("chapter_1", LoadSceneMode.Single);
    }
}
