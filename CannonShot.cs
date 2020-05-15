using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShot : MonoBehaviour
{
    public M_Health mainPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            mainPlayer.modifyHealth(-1);
        }
    }
    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            mainPlayer.modifyHealth(-1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            mainPlayer.modifyHealth(-1);
        }
    }
    */
}
