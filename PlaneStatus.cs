using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneStatus : MonoBehaviour
{
    public List<ParticleSystem> parts;
    public GameObject particleHolder;
    public AudioSource audio;
    public AudioClip crashSound;
    public Animator planeAnim;

    private void Start()
    {
        parts = new List<ParticleSystem>();
        var e = particleHolder.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem p in e)
        {
            parts.Add(p);
            p.gameObject.SetActive(false);
        }
    }
    /*public void activateParticles()
    {
        foreach (ParticleSystem p in parts)
        {
            p.gameObject.SetActive(true);
        }
    }*/

    public void beginCrash()
    {
        Debug.Log("Playing Crash");
        audio.PlayOneShot(crashSound);
        planeAnim.SetBool("crash", true);

    }
}
