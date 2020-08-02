using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Subs : MonoBehaviour
{
    public bool loopWork, OneFirstPlay, WorkInPlace;
    public string[] text;
    private bool enter;
    public float Timer;
    private float TimerDown;
    private int i = 0;
    public int WidthOfLabel;
    public int HeightOfLabel;
    public int FontSize;
    public float waitTimer = 3000f;

    // Start is called before the first frame update
    void Start()
    {
        TimerDown = Timer;
    }

    // Update is called once per frame
    void Update()
    {       
        waitTimer -= Time.deltaTime;
        if (i == text.Length)
        {
            if (!loopWork)
            {
                Destroy(gameObject);
            }
            else
            {
                enter = false;
            }
        }
        if (enter && waitTimer <= 0f)
        {
            if (TimerDown > 0)
                TimerDown -= Time.deltaTime;
            if (TimerDown < 0)
                TimerDown = 0;
            if (TimerDown == 0)
            {
                TimerDown = Timer;
                i++;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            enter = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (WorkInPlace)
            {
                enter = false;
            }

            if (loopWork)
            {
                enter = false;
                WorkInPlace = true;
                TimerDown = Timer;
                i = 0;
            }
            if (OneFirstPlay)
            {
                if (WorkInPlace)
                    Destroy(gameObject);
            }
        }
    }


    void OnGUI()
    {       
        if (enter && i < text.Length && waitTimer <= 0f)
        {
            int boxLength = text[i].Length * 14;
            waitTimer = 0;
            var guiStyle = new GUIStyle();
            guiStyle.fontSize = FontSize; //РЕДАЧЬ АНДРЕЙ
            guiStyle.normal.textColor = Color.white;
            GUI.Box(new Rect(Screen.width / 2 - boxLength / 2 - 10, Screen.height / 2 + Screen.height / 3 + Screen.height / 10, boxLength, 40), "");
            GUI.Label(new Rect(Screen.width / 2 - boxLength / 2, Screen.height / 2 + Screen.height / 3 + Screen.height / 10, 0, 0), text[i], guiStyle);

        }
    }
}
