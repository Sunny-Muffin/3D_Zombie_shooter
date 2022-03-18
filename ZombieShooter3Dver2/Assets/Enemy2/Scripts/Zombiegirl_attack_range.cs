using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombiegirl_attack_range : MonoBehaviour
{
    public bool ZG_a_r = false;
    void OnTriggerEnter(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject.name == "Player2_Trigger")
        {
            ZG_a_r = true;
            Debug.Log("Entered in Zombiegirl`s attack range");
            Debug.Log("ZG_a_r: " + ZG_a_r);
        }
    }

    void OnTriggerStay(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject.name == "Player2_Trigger")
        {
            Debug.Log("Still in Zombiegirl`s attack range");
            Debug.Log("ZG_a_r: " + ZG_a_r);
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject.name == "Player2_Trigger")
        {
            ZG_a_r = false;
            Debug.Log("Quit from Zombiegirl`s attack range");
            Debug.Log("ZG_a_r: " + ZG_a_r);
        }
    }

}
