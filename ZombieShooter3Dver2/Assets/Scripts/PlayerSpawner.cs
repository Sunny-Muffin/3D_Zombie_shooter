using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // GO
    public GameObject playerPrefab;
    public Transform spawnPos;
    public GameObject playerClone;
    public GameObject deathCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerClone = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);
        deathCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
