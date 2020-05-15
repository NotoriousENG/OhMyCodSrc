using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBarrier : MonoBehaviour
{
    public List<GameObject> activationObjects;
    public List<GameObject> deactivationObjects;
    // Start is called before the first frame update
    void Start()
    {
        //activationObjects = new List<GameObject>();
        //deactivationObjects = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var obj in activationObjects)
            {
                obj.SetActive(true);
            }
            foreach (var obj in deactivationObjects)
            {
                obj.SetActive(false);
            }
        }
    }
}
