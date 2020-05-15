using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGlockSound : MonoBehaviour
{
    public AudioSource glockNoises;
    public void Update()
    {
        int rando = Random.Range(0, 100);
        if(rando < 100)
        {
            glockNoises.Play();
        }
    }
}
