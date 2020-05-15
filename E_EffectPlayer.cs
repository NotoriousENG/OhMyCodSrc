using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_EffectPlayer : MonoBehaviour
{
    public GameObject soundManger;
    public AudioSource soundEffectPlayer;
    public ParticleSystem hitParticle;
    public bool playEffect = false;
    private void Update()
    {
        if (playEffect)
        {
            playEffect = false;
            AudioSource effectAudio = soundEffectPlayer;
            E_SoundEffectManager soundEffectManager = soundManger.GetComponent<E_SoundEffectManager>();
            Debug.Log(soundEffectManager);
            Debug.Log(effectAudio);
            effectAudio.clip = soundEffectManager.giveHitSound();
            effectAudio.Play();
            StartCoroutine(playDamageEffect());
            //playEffect = false;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
       // StartCoroutine(waitABit());
        if (collision.tag.Equals("Enemy"))
        {
            playEffect = true;
        }

    }

    private IEnumerator playDamageEffect()
    {
        ParticleSystem ps = hitParticle;
        //ps.gameObject.SetActive(true);
        //ps.startColor = Color.red;
        ParticleSystem.EmitParams emitOverride = new ParticleSystem.EmitParams();
        emitOverride.startLifetime = 0.3f;
        ps.Emit(emitOverride, 20);
        Debug.Log("damageEffected Played");
        yield return new WaitForSeconds(0.3f);
        Debug.Log("This got waited");

        //ps.gameObject.SetActive(false);
        //yield return new WaitForSeconds(0.5f);
    }
    private IEnumerator waitABit()
    {
        yield return new WaitForSeconds(1f);
    }
}
