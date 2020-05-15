using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PlayerKnockBack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float mass = 3.0f;
    public float forceMag = 100.0f;
    public GameObject soundManger;
    public AudioSource soundEffectPlayer;
    public ParticleSystem hitParticle;

    Vector3 impact = Vector3.zero;

    void Start()
    {
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(impact.magnitude > 0.2)
        {
            player.GetComponent<CharacterController>().Move(impact * Time.deltaTime);
            impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
        }
    }

    public void playerKnockBack(Collider collision)
    {
        Vector3 direction = this.transform.position - collision.transform.position;
        AddImpact(direction, forceMag);
        AudioSource effectAudio = soundEffectPlayer;
        E_SoundEffectManager soundEffectManager = soundManger.GetComponent<E_SoundEffectManager>();
        Debug.Log(soundEffectManager);
        Debug.Log(effectAudio);
        effectAudio.clip = soundEffectManager.giveDamageSound();
        effectAudio.Play();
        StartCoroutine(playDamageEffect());
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Glock"))
        {
            Debug.Log("Hit");
            playerKnockBack(collision);
        }
        //playerKnockBack(collision);

    }

    private IEnumerator playDamageEffect()
    {
        ParticleSystem ps = hitParticle;
        ps.gameObject.SetActive(true);
        //ps.startColor = Color.red;
        ParticleSystem.EmitParams emitOverride = new ParticleSystem.EmitParams();
        emitOverride.startLifetime = 0.3f;
        ps.Emit(emitOverride, 20);
        yield return new WaitForSeconds(0.3f);
        ps.gameObject.SetActive(false);
        //yield return new WaitForSeconds(0.5f);
    }
    private void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0)
        {
            dir.y = -dir.y;
        }
        dir.y = 0;
        impact += dir.normalized * force / mass;
    }
}
