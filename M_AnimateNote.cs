using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_AnimateNote : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private Animator animator;
    private int i = -1;
    private string[] note1 = {"note!", "legible!", "3701",
        "I can't live off of pineapples anymore, my sanity is at it's limits.", "These crabby henchmen have hoarded my ship parts for too long.",
        "On top of that 5 of my SOS rocks have been scatteered across the island",
        "I leave tomorrow to fight against the Gloctapus, scoundrel of the sea.", 
        "I'll get my ship parts back no matter what!", 
        "Ye who read this, I leave you with these words:",
        "It's dangerous to go alone ... take these mighty weapons!", "Haha how about no!"};
    private M_PlayerController player;
    private M_Camera camr;

    public toggledBarrier invisWallDeactivate;

    private void Start() 
    {
        dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<M_PlayerController>();
        camr = GetComponent<M_Camera>();
    }
    private void Update() 
    {
        if (dialogueManager.curr.Contains(note1[0]))
        {
            i = 0;
            animator.SetFloat("Animation", i);
            player.StopMovement();
            player.enabled = false;
            camr.isRotatable = false;
        }
        if (i >= 0 && i < note1.Length)
        {
            if(dialogueManager.curr.Contains(note1[i]))
            {
                i++;
                animator.SetFloat("Animation", i);
            }
        }
        else if (i >= note1.Length && Input.GetButtonDown("Jump"))
        {
            animator.SetFloat("Animation", -1);
            camr.isRotatable = true;
            player.enabled = true;
            if (invisWallDeactivate.gameObject.activeInHierarchy)
            {
                invisWallDeactivate.toggleBarrier();
            }
        }
    }
    
}
