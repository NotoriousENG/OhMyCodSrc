using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_FaceCamera : MonoBehaviour
{
    private void Update() {
        transform.LookAt(Camera.main.transform);
    }
}
