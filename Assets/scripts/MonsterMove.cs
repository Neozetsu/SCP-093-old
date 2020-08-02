using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public Transform Player;
    public Transform Monster;
    public Rigidbody Rigidbody;
    public int Speed;

    void Update()
    {
        var a = (Player.position - Monster.position);
        a.Normalize();
        Rigidbody.velocity = Speed*a;


        Monster.LookAt(Player);
    }
}
