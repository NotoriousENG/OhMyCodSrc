using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_zoomInOnFace : MonoBehaviour
{
    public GameObject playerFace;
    public float distance;

    private void Start() {
        transform.position = playerFace.transform.position;
    }
    private void Update() {
        transform.position = playerFace.transform.position;
        transform.rotation = playerFace.transform.rotation;
    }
}
