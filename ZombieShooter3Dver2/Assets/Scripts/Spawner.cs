using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject EnemyPrefab;
    public float spawnCD = 0.5f;
    public int zombieMax = 10;
    private int zombieCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCD());
    }

    // Update is called once per frame
    void Repeat()
    {
        StartCoroutine(SpawnCD());
    }

    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(spawnCD);
        Instantiate(EnemyPrefab, SpawnPos.position, Quaternion.identity);
        if (zombieCount < zombieMax)
        {
            zombieCount++;
            Repeat();
        }
        else
        {
            yield break;
        }
    }
}
