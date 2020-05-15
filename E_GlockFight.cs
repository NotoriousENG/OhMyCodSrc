using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_GlockFight : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public Transform prevPlace;
    public Transform center;
    public Vector3 size;
    public float startScale = 0.01f;
    public float endScale = 0.75f;
    public float frameAmount = 20;
    public float colorChange = 0.05f;
    private bool readyToFight = true;
    public float yOffest = 0.5f;
    public int numOfAttacks = 1;
    //tranform stuff

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TO REMOVE
        if (readyToFight)
        {
            for (int i = 0; i < numOfAttacks; i++)
            {
                RandomBehavior();
            }           
            readyToFight = false;
        }
    }

    public void TargetingBehavior()
    {
        
    }
    public void RandomBehavior()
    {
        Vector3 pos = center.localPosition + new Vector3(Random.Range(-size.x / 2, size.x/2), yOffest, Random.Range(-size.z / 2, size.z / 2));
        StartCoroutine(targetingReticule(pos));

        //GameObject temp = Instantiate(target, pos, Quaternion.identity);
    }
    
    public IEnumerator targetingReticule(Vector3 pos)
    {
        float currentScale = startScale;
        bool flagToSTOP = false;
        GameObject temp = Instantiate(target, pos, Quaternion.Euler(-90,0,0));
        Transform hitBox = temp.transform.GetChild(0);
        temp.SetActive(true);
        hitBox.gameObject.SetActive(false);
        
        temp.transform.SetParent(this.transform);
        Debug.Log(temp.transform.localScale);
        temp.transform.localScale = temp.transform.localScale = Vector3.one * currentScale;
        float scaleDX = (endScale - startScale) / frameAmount;
        Debug.Log(scaleDX);
        while (!flagToSTOP)
        {
            currentScale += scaleDX;
            if(currentScale > endScale)
            {
                flagToSTOP = true;
                currentScale = endScale;
            }
            temp.transform.localScale = Vector3.one * currentScale;
            yield return new WaitForSeconds(Time.deltaTime*2);
        }
        Color colorOfTarget = temp.GetComponent<SpriteRenderer>().color;
        flagToSTOP = false;
        Debug.Log(colorOfTarget);
        while (!flagToSTOP)
        {
            colorOfTarget.r -= colorChange;
            colorOfTarget.b -= colorChange;
            colorOfTarget.g -= colorChange;
            if (colorOfTarget.r < 0.01f && colorOfTarget.b < 0.01f && colorOfTarget.g < 0.01f)
            {
                flagToSTOP = true;
                colorOfTarget = Color.black;
            }
            temp.GetComponent<SpriteRenderer>().color = colorOfTarget;
            yield return new WaitForSeconds(Time.deltaTime*2);
        }
        hitBox.gameObject.SetActive(true);
        temp.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        StartCoroutine(playDamageEffect(temp.transform.GetChild(1).GetComponent<ParticleSystem>()));
        StartCoroutine(playDamageEffect(temp.transform.GetChild(1).transform.GetChild(0).GetComponent<ParticleSystem>()));
        //hitBox.gameObject.SetActive(false);
        yield return new WaitForSeconds(Time.deltaTime * 10);
        hitBox.gameObject.SetActive(false);
        yield return new WaitForSeconds(Time.deltaTime * 50);
        Destroy(temp);
        readyToFight = true;
        
    }
    private IEnumerator playDamageEffect(ParticleSystem ps)
    {
        ParticleSystem particle = ps;
        ps.gameObject.SetActive(true);
        ParticleSystem.EmitParams emitOverride = new ParticleSystem.EmitParams();
        emitOverride.startLifetime = 0.5f;
        ps.Emit(emitOverride, 20);
        yield return new WaitForSeconds(0.5f);
        ps.gameObject.SetActive(false);
    }
}
