using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMonster : MonoBehaviour
{
    public GameObject Monster;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Monster.SetActive(true);
    }
}
