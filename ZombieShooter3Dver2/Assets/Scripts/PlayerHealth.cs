using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    // Health properties
    public float maxHealth = 100f;
    private float currentHealth;
    public bool isAlife;

    // Texts
    public Text health;

    // GO
    public GameObject cameraHolder;
    public GameObject mainCamera;
    public AudioSource _audioSource;
    public AudioClip Scream;
    public GameObject canvas;
    public GameObject redScreen;
    public GameObject Player;
    public GameObject weaponHolder;



    // Start is called before the first frame update
    void Start()
    {
        isAlife = true;
        currentHealth = maxHealth;
        health.text = "Health: " + currentHealth.ToString();

        
        canvas = GameObject.FindGameObjectWithTag("RedScreen");
        redScreen = canvas.transform.Find("RedScreen").gameObject;

        cameraHolder = GameObject.FindGameObjectWithTag("MainCamera2");
        mainCamera = cameraHolder.transform.Find("Main Camera").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(float damage)
    {
        if (isAlife == true)
        {
            currentHealth -= damage;
            health.text = "Health: " + currentHealth.ToString();

            if (currentHealth <= 0)
            {
                isAlife = false;
                StartCoroutine(Die());
            }
        }
    }

    IEnumerator Die()
    {
        Player.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
        Player.GetComponent<FirstPersonController>().m_RunSpeed = 0;
        Player.GetComponent<FirstPersonController>().m_JumpSpeed = 0;
        weaponHolder.SetActive(false);
        _audioSource.enabled = true;
        _audioSource.clip = Scream;
        _audioSource.Play();
        redScreen.SetActive(true);

        yield return new WaitForSeconds(3f);

        redScreen.SetActive(false);
        mainCamera.SetActive(true);
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
