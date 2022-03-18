using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieCounter : MonoBehaviour
{
    // Texts
    public Text counter;

    // variables
    public int totalZombies;
    public int zombiesKilled;
    private int zombiesLeft;
    private bool bossSpawned;


    //GO
    public GameObject bossSpawner;

    // Music
    public AudioSource audioSource;
    public AudioClip gameMusic;
    public AudioClip bossMusic;

    // Start is called before the first frame update
    void Start()
    {
        zombiesKilled = 0;
        zombiesLeft = totalZombies;
        bossSpawned = false;
        audioSource.clip = gameMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Zombies killed " + zombiesKilled);
        if (zombiesLeft <= 0 && bossSpawned == false)
        {
            zombiesLeft = 0;
            SpawnBoss();
        }
        else if (zombiesLeft > 0)
        {
            zombiesLeft = totalZombies - zombiesKilled;
        }
        else
        {
            return;
        }

        /*
        if (timeForBOSS == false)
            zombiesLeft = totalZombies - zombiesKilled;
        else
            zombiesLeft = 0;
        */

        counter.text = zombiesLeft + " ZOMBIES LEFT";
    }

    private void SpawnBoss ()
    {
        bossSpawner.SetActive(true);
        bossSpawned = true;
        PlayBossMusic();
    }

    private void PlayBossMusic()
    {
        audioSource.clip = bossMusic;
        audioSource.Play();
    }
}
