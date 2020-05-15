using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Add_Sunglasses : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private Animator animator;

    private void Start() 
    {
        dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
        animator = GetComponent<Animator>();
    }
    private void Update() 
    {
        if (dialogueManager.curr.Contains("Sleeping"))
        {
            animator.SetBool("Equip", true);
        }
    }
    
}
