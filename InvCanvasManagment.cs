using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InvCanvasManagment : MonoBehaviour
{
    public GameObject keyListEmpty;
    public Image pickupPrefab;
    public GameObject rockListEmpty;
    public Sprite rockSprite;

    //Contains the names of pickups
    public List<Image> pickups;
    public List<Image> rocks;

    // Start is called before the first frame update
    void Start()
    {
        pickups = new List<Image>();
        rocks = new List<Image>();
    }


    public void changeScene()
    {
        SceneManager.LoadScene(2);
    }


    //Called on pickup pickup. Make sure that however triggered, the pickup GameObject's Sprite is saved somehow
    public void addPickupToUI(Sprite pickupSprite)
    {
        Image newKey = Instantiate(pickupPrefab, keyListEmpty.transform);
        newKey.transform.SetParent(keyListEmpty.transform, false);
        Vector3 newPosition = new Vector3(newKey.GetComponent<RectTransform>().rect.width * pickups.Count,
            newKey.GetComponent<RectTransform>().localPosition.y, newKey.GetComponent<RectTransform>().localPosition.z);

        newKey.GetComponent<RectTransform>().localPosition = newPosition;
        newKey.sprite = pickupSprite;
        pickups.Add(newKey);

        if (pickups.Count == 3)
        {
            changeScene();
        }

    }

    public void addRockToUI()
    {
        Image newRock = Instantiate(pickupPrefab, rockListEmpty.transform);
        newRock.transform.SetParent(rockListEmpty.transform, false);
        Vector3 newPosition = new Vector3(newRock.GetComponent<RectTransform>().rect.width * rocks.Count,
            newRock.GetComponent<RectTransform>().localPosition.y, newRock.GetComponent<RectTransform>().localPosition.z);

        newRock.GetComponent<RectTransform>().localPosition = newPosition;
        newRock.sprite = rockSprite;
        rocks.Add(newRock);
    }

    public bool checkForAllPickup()
    {
        if (pickups.Count == 3)
        {
            return true;
        }
        return false;
    }

    //Returns the amount of rocks removed for the SOS script
    public int removeRocks()
    {
        int rockCount = rocks.Count;
        rocks.Clear();
        var i = rockListEmpty.GetComponentsInChildren<Image>();
        foreach (Image t in i)
        {
            Destroy(t);
        }
        return rockCount;
    }

}
