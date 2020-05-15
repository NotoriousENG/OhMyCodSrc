using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_AnimateNote2 : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private Animator animator;
    private int i = -1;
    private string[] note1 = {"Hm ... another note, let's read it . . .", 
        "Captains Log: Day F (for Respect)",
        "I'm at the end of the line, I've made my last cast only to be shelled raw and left to rot.",
        "I didn't have it . . . the ultimate weapon", 
        "Perhaps if I slayed 1,000,000,000 crabs, I'd have enough chiten to create it, the ultimate weapon",
        "I only had the patience to slay 999,999,324",
        "Beware the Gloctapus",
        "It is your... ",
        "Looks like he's ...",
        "Sleeping with the fishies."};
    private M_PlayerController player;
    private M_Camera camr;

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
            animator.SetFloat("Animation2", i);
            player.StopMovement();
            player.enabled = false;
            camr.isRotatable = false;
        }
        if (i >= 0 && i < note1.Length)
        {
            if(dialogueManager.curr.Contains(note1[i]))
            {
                i++;
                animator.SetFloat("Animation2", i);
                Debug.Log("Note progress: " + i + " / " + note1.Length);
            }
        }
        else if (i >= note1.Length && Input.GetButtonDown("Jump"))
        {
            Debug.Log("End of note");
            animator.SetFloat("Animation2", -1);
            camr.isRotatable = true;
            player.enabled = true;
        }
    }
    
}
