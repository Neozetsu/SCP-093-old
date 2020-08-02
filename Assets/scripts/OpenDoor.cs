using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    float smooth = 2.0f;
    public float DoorOpenAngle;
    private bool open;
    private bool IsInteractive;
    private Vector3 defaultRot;
    private Vector3 openRot;
    public Texture2D Hand;

    // Start is called before the first frame update
    void Start()
    {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        }
        else
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);

        if (Input.GetKeyDown(KeyCode.E) && IsInteractive)
            open = !open;
    }

    private void OnGUI()
    {
        if (IsInteractive)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 17f, Screen.height / 2 - 20f, 50, 50), Hand);
            GUI.Label(new Rect((Screen.width / 2) - 97f, (Screen.height) / 2 + 280f, 200f, 30f), "Нажмите E для взаимодействия");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            IsInteractive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            IsInteractive = false;
    }
}
