using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_JustinCamActivate : MonoBehaviour
{
    public Skybox skybox;
    public Camera jCam;

    private void Update() 
    {
        if(skybox.enabled)
        {
            jCam.enabled = false;
        }
        else
        {
            jCam.enabled = true;
        }
    }
    
}
