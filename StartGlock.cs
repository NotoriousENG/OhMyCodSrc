using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGlock : MonoBehaviour
{
    public GameObject attackThing;
    public GameObject GLOCK;
    // Start is called before the first frame update
    void Start()
    {
        attackThing.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        attackThing.SetActive(true);
    }
}
