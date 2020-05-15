using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlockHitScript : MonoBehaviour
{
    public GameObject glocktopus;
    public GameObject finalDrop;
    public BoxCollider glockBox;
    public Animator playerAnimator;
    public E_ShakeManager shakeCommands;
    public int counter = 0;
    public bool canBeHitAgain = true;
    public bool duringShake = false;
    public GameObject targetingSHIT;
    private Vector3 originalSizeOfBox;
    // Start is called before the first frame update
    void Start()
    {
        originalSizeOfBox = glockBox.size;
    }

    // Update is called once per frame
    void Update()
    {
        if (canBeHitAgain && duringShake)
        {
            canBeHitAgain = false;
            StartCoroutine(waitABit());
        }
        if (playerAnimator.GetBool("Attack"))
        {
            glockBox.isTrigger = true;
            //glockBox.size = glockBox.size + new Vector3(0.2f, 0.2f, 0.2f);
        }
        else if (playerAnimator.GetBool("Attack") == false)
        {
            glockBox.size = originalSizeOfBox;
            glockBox.isTrigger = false;

        }
        //glockBox.size = originalSizeOfBox;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && canBeHitAgain)
        {
            Debug.Log("Glock Entered");
            counter++;
            duringShake = true;
            if (counter == 1)
            {
                // StopCoroutine("ShakeTheGlock");
                StartCoroutine(shakeCommands.ShakeTheGlock(10));
            }
            if (counter == 2)
            {
                StopCoroutine("ShakeTheGlock");
                StartCoroutine(shakeCommands.ShakeTheGlock(30));
            }
            if(counter == 3)
            {
                StopCoroutine("ShakeTheGlock");
                glocktopus.GetComponent<Animator>().SetBool("isDead", true);
                Debug.Log("Glock is dead");
                finalDrop.SetActive(true);
                StartCoroutine(shakeCommands.KnockOver(90));
                Destroy(targetingSHIT);
                //GameObject temp = Instantiate(target, pos, Quaternion.Euler(0, 0, 0));

                //glocktopus.GetComponent<Animator>().SetBool("isDead",true);
            }
        }
    }

    public IEnumerator waitABit()
    {
        duringShake = true;
        yield return new WaitForSeconds(1);
        canBeHitAgain = true;
        duringShake = false;

    }
}
