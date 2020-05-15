using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_InitialCutscene : MonoBehaviour
{
    private DialogueTrigger thisTrigger;
    private BoxCollider thisTriggerCollider;
    private Vector3 thisColliderOriginalSize;
    private bool startChecking = false;
    // Start is called before the first frame update
    void Start()
    {
        thisTrigger = gameObject.GetComponent<DialogueTrigger>();
        thisTriggerCollider = gameObject.GetComponent<BoxCollider>();
        thisColliderOriginalSize = thisTriggerCollider.size;
        thisTrigger.TriggerWithButton = false;
        StartCoroutine(WaitABit());
    }

    // Update is called once per frame
    void Update()
    {
        if (!thisTrigger.stillGoing && startChecking)
        {
            thisTriggerCollider.size = thisColliderOriginalSize;
            startChecking = false;
        }
    }

    IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(2f);
        thisTriggerCollider.size = thisColliderOriginalSize * 50;
        yield return new WaitForSeconds(1f);
        //thisTriggerCollider.size = thisColliderOriginalSize;
        thisTrigger.TriggerWithButton = true;
        startChecking = true;

    }
}
