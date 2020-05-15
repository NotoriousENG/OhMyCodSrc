using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ShakeManager : MonoBehaviour
{
    Vector3 startingPos;
    Vector3 startingRotation;
    public const float SPEED = 2.0f;
    public float amount = 1.0f;

    void Awake()
    {
        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;
        startingPos.z = transform.position.z;
        startingRotation.x = transform.rotation.x;
        startingRotation.y = transform.rotation.y;
        startingRotation.z = transform.rotation.z;
    }

    // Update is called once per frame

    public IEnumerator ShakeTheGlock(float amount)
    {
        gameObject.transform.rotation = Quaternion.Euler(startingRotation.x, startingRotation.y, startingRotation.z);
        float temp = amount;
        int counter = 0;
        bool shakeOGflag = true;
        while (shakeOGflag)
        {
            float xRot = startingRotation.x + Mathf.Sin(Time.time * SPEED) * temp;
            float zRot = startingRotation.z + Mathf.Cos(Time.time * SPEED) * temp;
            if(counter == 2)
            {
                shakeOGflag = false;

            }
            if ( Math.Abs(zRot - startingRotation.z) < 1.0f)
            {
                counter++;
            }
            gameObject.transform.rotation = Quaternion.Euler(xRot, startingRotation.y, zRot);
            yield return new WaitForSeconds(Time.deltaTime);

        }
        bool flag = true;
        while (flag)
        {
            float xRot = startingRotation.x + Mathf.Sin(Time.time * SPEED) * temp;
            float zRot = startingRotation.z + Mathf.Cos(Time.time * SPEED) * temp;
            if(Math.Abs(xRot - startingRotation.x) < 0.01 && Math.Abs(zRot - startingRotation.z) < 0.01)
            {
                flag = false;
                xRot = startingRotation.x;
                zRot = startingRotation.z;
            }
            gameObject.transform.rotation = Quaternion.Euler(xRot, startingRotation.y, zRot);
            yield return new WaitForSeconds(Time.deltaTime);
            temp -= (amount/200);
        }
    }
    public IEnumerator KnockOver(float amount)
    {
        gameObject.transform.rotation = Quaternion.Euler(startingRotation.x, startingRotation.y, startingRotation.z);
        bool flag = true;
        float xRot = 0;
        float zRot = 0;
        while (flag)
        {   
            //xRot += Mathf.Sin(xRot * SPEED) * amount;
            xRot += amount * Time.deltaTime;
           
            Debug.Log(xRot);
            //zRot = Mathf.Cos(Time.time * SPEED) * amount;
            if(Math.Abs(xRot) > 90)
            {
                flag = false;
                xRot = 90;
            }
            gameObject.transform.rotation = Quaternion.Euler(xRot, startingRotation.y, startingRotation.z);
            yield return new WaitForSeconds(Time.deltaTime);
            //amount += (amount / 200);
        }
        Destroy(gameObject);
    }
}
