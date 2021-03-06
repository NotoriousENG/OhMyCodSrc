﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_MoveAlongPoints : MonoBehaviour
{
    List<Transform> transforms = new List<Transform>();
    int currIndex = 0;
    public float speed = 2f;
    public bool isPlatform = false;
    M_MoveWithPlatform moveWithPlatform;
    private void Start() 
    {
        InitializeList();
        InitializePlatform();
    }
    void InitializePlatform()
    {
        if (isPlatform)
        {
            moveWithPlatform = gameObject.AddComponent<M_MoveWithPlatform>();
        }
    }
    private void Update() 
    {
        DoMove();
    }
    void InitializeList()
    {
        transforms.Clear();
        var transformContainer =  transform.parent.Find("MovementPoints");
        foreach (Transform t in transformContainer)
        {
            transforms.Add(t);
        }
    }
    void GetNextIndex()
    {
        currIndex ++;
        if (currIndex >= transforms.Count)
        {
            currIndex = 0;
        }
        else if (currIndex < 0)
        {
            currIndex = transforms.Count;
        }
        
    }
    void DoMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, transforms[currIndex].position, speed * Time.deltaTime);
        if (transform.position == transforms[currIndex].position)
        {
            GetNextIndex();
        }
    }
    private void OnDrawGizmos() 
    {
        InitializeList();
        Gizmos.color = Color.red;
        for (int i = 0; i < transforms.Count - 1; i++)
        {
            Gizmos.DrawLine(transforms[i].position, transforms[i+1].position);
            if (i == transforms.Count - 2)
            {
                Gizmos.DrawLine(transforms[i+1].position, transforms[0].position);
            }
        }
    }
    
}
