using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_SoundEffectManager : MonoBehaviour
{
    [SerializeField]
    public List<AudioClip> wetSounds = new List<AudioClip>();
    [SerializeField]
    public List<AudioClip> missSounds = new List<AudioClip>();
    [SerializeField]
    public List<AudioClip> damageSounds = new List<AudioClip>();
    public AudioClip giveHitSound()
    {
        int rando = Random.Range(0, wetSounds.Count);
        return wetSounds[rando];
    }
    public AudioClip giveMissSound()
    {
        int rando = Random.Range(0, missSounds.Count);
        return wetSounds[rando];
    }
    public AudioClip giveDamageSound()
    {
        int rando = Random.Range(0, damageSounds.Count);
        return damageSounds[rando];
    }

}
