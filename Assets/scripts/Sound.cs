using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip[] StepSound;
    public float AudioStepLength = 1f;
    public CharacterController Controller;
    int index = 0;
    void Start()
    {
        InvokeRepeating("PlaySound", AudioStepLength, AudioStepLength);
    }

    void PlaySound()
    {
        if (Controller.isGrounded && Controller.velocity.magnitude > 0.3)
        {
            var newIndex = Random.Range(0, StepSound.Length);
            while (index == newIndex)
                newIndex = Random.Range(0, StepSound.Length);
            index = newIndex;
            Audio.clip = StepSound[index];
            Audio.Play();
        }
    }
}
