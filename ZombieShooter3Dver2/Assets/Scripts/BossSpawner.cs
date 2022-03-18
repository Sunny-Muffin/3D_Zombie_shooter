using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject BossPrefab;
    private GameObject bossClone;
    public GameObject winCamera;
    public GameObject player;

    // Start is called before the first frame update
    private void OnEnable()
    {
        bossClone = Instantiate(BossPrefab, SpawnPos.position, Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (bossClone == null)
        {
            //Debug.Log("You WON!");
            StartCoroutine(WinGame());

        }
    }

    IEnumerator WinGame()
    {
        yield return new WaitForSeconds(3f);
        winCamera.SetActive(true);
        Destroy(player);
    }
}
