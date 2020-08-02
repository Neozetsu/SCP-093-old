using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    public GameObject Light;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Light.SetActive(false);
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Light.SetActive(true);
    }
}
