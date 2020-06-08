using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float standingTreshold = 3f; //afwijking dat de Pin mag hebben bij staan

    // Update is called once per frame
    void Update()
    {
        print(name + IsStanding()); //test om te zien welke Pin staat en welke niet
    }

    public bool IsStanding()
    {
        UnityEngine.Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if(tiltInX < standingTreshold && tiltInZ < standingTreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
