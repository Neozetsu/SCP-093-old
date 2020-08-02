using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public Transform playerCam;
    public ScreenFader screenFader;
    public Texture2D Hand;
    public float distance;
    private bool isInteractive;
    public GameObject disk;
    private bool TakeDisk = false;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCam.position, playerCam.forward, out hit))
        {
            if (hit.distance <= distance)
            {
                switch (hit.collider.tag)
                {
                    case "Mirror":
                        if (TakeDisk)
                        {
                            isInteractive = true;
                            if (Input.GetKeyDown(KeyCode.E))
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
                        }
                        break;

                    case "Pit":
                        isInteractive = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Texture2D nullTexture = new Texture2D(1, 1) as Texture2D;
                            nullTexture.SetPixel(0, 0, Color.black);
                            nullTexture.Apply();
                            screenFader.colorTexture = nullTexture;
                            screenFader.fadeColor = Color.black;
                            screenFader.fadeSpeed = 0.9f;
                            screenFader.fadeState = ScreenFader.FadeState.In;
                            Invoke("LoadTunnelScene", 1 / screenFader.fadeSpeed);
                        }
                        break;

                    case "Disk":
                        isInteractive = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            hit.collider.tag = "Untagged";
                            TakeDisk = true;
                            disk.gameObject.SetActive(false);
                        }
                        break;

                    case "Back":
                        isInteractive = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Texture2D nullTexture = new Texture2D(1, 1) as Texture2D;
                            nullTexture.SetPixel(0, 0, Color.black);
                            nullTexture.Apply();
                            screenFader.colorTexture = nullTexture;
                            screenFader.fadeColor = Color.black;
                            screenFader.fadeSpeed = 0.9f;
                            screenFader.fadeState = ScreenFader.FadeState.In;
                            Invoke("LoadEndScene", 1 / screenFader.fadeSpeed);
                        }
                        break;


                    default:
                        isInteractive = false;
                        break;
                }
                
            }
            else isInteractive = false;
            
        }
    }

    private void OnGUI()
    {
        if (isInteractive)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 17f, Screen.height / 2 -20f, 50, 50), Hand);
            GUI.Label(new Rect((Screen.width / 2) - 97f, (Screen.height) / 2 + 280f, 200f, 30f), "Нажмите E для взаимодействия");
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("chapter_1", LoadSceneMode.Single);
    }

    void LoadTunnelScene()
    {
        SceneManager.LoadScene("chapter_1_tunnel", LoadSceneMode.Single);
    }

    void LoadEndScene()
    {
        SceneManager.LoadScene("chapter_1_end", LoadSceneMode.Single);
    }
}
