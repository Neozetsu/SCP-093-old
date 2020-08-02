using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseLook : MonoBehaviour {

    public Pause pause;

    public float sensitiveX;
    public float sensitiveY;

    const float minX = -360;
    const float maxX = 360;
    const float minY = -60;
    const float maxY = 60;

    Quaternion originalRot;

    float rotX;
    float rotY;

    Transform parent;

    void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        originalRot = transform.localRotation;
        parent = gameObject.transform.parent;
        
	}

    void Update()
    {
        if (!pause.isPause)
        {
            rotX += Input.GetAxis("Mouse X") * sensitiveX;
            rotY += Input.GetAxis("Mouse Y") * sensitiveY;

            rotX = rotX % 360;
            rotY = rotY % 360;
            rotX = Mathf.Clamp(rotX, minX, maxX);
            rotY = Mathf.Clamp(rotY, minY, maxY);

            Quaternion quaternionX = Quaternion.AngleAxis(rotX, Vector3.up);
            Quaternion quaternionY = Quaternion.AngleAxis(rotY, Vector3.left);

            transform.localRotation = originalRot * quaternionY;
            parent.localRotation = originalRot * quaternionX;
        }
    }
}
