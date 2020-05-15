using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggledBarrier : MonoBehaviour
{
    public bool activeAtStart = true;
    void Start()
    {
        if (activeAtStart)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void toggleBarrier()
    {
        if (this.gameObject.activeInHierarchy)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
