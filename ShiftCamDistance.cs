using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftCamDistance : MonoBehaviour
{
    public Animator camAnim;
    public bool zoomOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (zoomOut && !camAnim.GetBool("zoomOut"))
            {
                camAnim.SetBool("zoomOut", zoomOut);
            }
            else if (!zoomOut && camAnim.GetBool("zoomOut"))
            {
                camAnim.SetBool("zoomOut", zoomOut);
            }
            
        }
    }
}
