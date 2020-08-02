using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    float timer;
    [HideInInspector] public bool isPause;
    bool guiPause;

    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                isPause = false;
                Cursor.visible = false;
            }
            else
                isPause = true;
        }
        if (isPause)
        {
            timer = 0;
            guiPause = true;

        }
        else
        {
            timer = 1f;
            guiPause = false;
            Cursor.visible = false;
        }
    }
    public void OnGUI()
    {
        if (guiPause)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (GUI.Button(new Rect((Screen.width / 2) - 75f, (Screen.height / 2) - 150f, 150f, 45f), "Продолжить"))
            {
                isPause = false;
                timer = 0;
                Cursor.visible = false;
            }
            if (GUI.Button(new Rect((Screen.width / 2) - 75f, (Screen.height / 2) - 100f, 150f, 45f), "Сохранить"))
            {

            }
            if (GUI.Button(new Rect((Screen.width / 2) - 75f, (Screen.height / 2) - 50f, 150f, 45f), "Загрузить"))
            {

            }
            if (GUI.Button(new Rect((Screen.width / 2) - 75f, (Screen.height / 2), 150f, 45f), "В Меню"))
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            }
        }
    }
}
