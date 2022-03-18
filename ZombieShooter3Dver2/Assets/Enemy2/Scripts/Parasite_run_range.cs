using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasite_run_range : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject.name == "Player2_Trigger")
        {
            Debug.Log("Entered in Parasite`s run range");
        }
    }

    void OnTriggerStay(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject.name == "Player2_Trigger")
        {
            Debug.Log("Still in Parasite`s run range");
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject.name == "Player2_Trigger")
        {
            Debug.Log("Quit from Parasite`s run range");
        }
    }

}