using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCamera : MonoBehaviour
{
    public GameObject mainCamera;

    void Update()
    {
        if (mainCamera.activeSelf == true && Input.GetKeyDown(KeyCode.Return))
        {
            // Debug.Log("Reloading level!");
            SceneManager.LoadScene("Swamp");
        }
    }
}
