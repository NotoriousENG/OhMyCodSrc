using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_CrabAI : MonoBehaviour
{
    public float speed = 5f;
    GameObject player;
    public float chase_range = 6f;
    public float attack_range = 1f;
    Animator animator;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }
    private void Update() {
        var distance = (player.transform.position - transform.position).magnitude;

        if(distance > chase_range)
        {
            animator.SetFloat("isIdling", 1);
            animator.SetFloat("Movement", 0);
        }
        else if (distance < chase_range && distance > attack_range)
        {
            var v =player.transform.position;
            transform.LookAt(2 * transform.position - v);
            transform.position =  Vector3.MoveTowards(transform.position, v, speed * Time.deltaTime);
            animator.SetFloat("isIdling", 0);
            animator.SetFloat("Movement", 1);
        }
        else
        {
            animator.SetFloat("isAttacking", 1);
        }

        
    }
}
