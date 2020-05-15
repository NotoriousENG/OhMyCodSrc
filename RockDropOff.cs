using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDropOff : MonoBehaviour
{
    public InvCanvasManagment inventory;
    private List<GameObject> rockList;
    public GameObject rocks;
    public PlaneStatus planeStatus;
    public GameObject notifier;
    // Start is called before the first frame update
    void Start()
    {
        rockList = new List<GameObject>();
        foreach(Transform t in rocks.transform)
        {
            rockList.Add(t.gameObject);
        }


    }

    public void updateList(int count)
    {
        int index = 0;
        int buffer = 0;
        bool allActive = true;

        for (int i = 0; i < count; i++)
        {
            if (!rockList[i + buffer].activeInHierarchy)
            {
                rockList[i + buffer].SetActive(true);
                
            }
            else
            {
                i--;
                buffer++;
            }
        }
        foreach (GameObject t in rockList)
        {
            if (!t.gameObject.activeInHierarchy)
            {
                allActive = false;
            }
        }
        if (allActive)
        {
            planeStatus.beginCrash();
            notifier.GetComponent<Animator>().SetBool("Play", true);
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            updateList(inventory.removeRocks());
        }
    }

}
