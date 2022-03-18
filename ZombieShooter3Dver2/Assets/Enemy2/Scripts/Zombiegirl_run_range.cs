using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombiegirl_run_range : MonoBehaviour
{
    public bool ZG_r_r = false;
    void OnTriggerEnter(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject.name == "Player2_Trigger")
        {
            ZG_r_r = true;
            Debug.Log("Entered in Zombiegirl`s run range");
            Debug.Log("ZG_r_r: " + ZG_r_r);
        }
    }

    void OnTriggerStay(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject.name == "Player2_Trigger")
        {
            Debug.Log("Still in Zombiegirl`s run range");
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject.name == "Player2_Trigger")
        {
            ZG_r_r = false;
            Debug.Log("Quit from Zombiegirl`s run range");
            Debug.Log("ZG_r_r: " + ZG_r_r);
        }
    }

}
