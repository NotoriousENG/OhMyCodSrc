using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_GlockShotSounds : MonoBehaviour
{
    public AudioSource glockNoises;
    public float chanceToFire;
    public void Update()
    {
        float rando = Random.Range(0, 100);
        if (rando < chanceToFire)
        {
            glockNoises.Play();
        }
    }
}
