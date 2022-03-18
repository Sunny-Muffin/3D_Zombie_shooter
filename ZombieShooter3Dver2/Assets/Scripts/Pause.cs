using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    public GameObject Player;
    public GameObject weaponHolder;
    public GameObject crosshair;
    //public AudioSource audiosource;
    //public FirstPersonController FPScontroller;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // спасибо святой паузе за то, что находит игрока по тегу

        weaponHolder = Player.transform.Find("FirstPersonCharacter").transform.Find("WeaponHolder").gameObject;
        crosshair = Player.transform.Find("Canvas").transform.Find("CrossHair").gameObject;
        weaponHolder.SetActive(true);
        crosshair.SetActive(true);
        /*
        if (weaponHolder != null)
        {
            Debug.Log("Found weaponHolder!");
        }
        else
            Debug.Log("Did not find weaponHolder!");

        if (crosshair != null)
        {
            Debug.Log("Found crosshair!");
        }
        else
            Debug.Log("Did not find crosshair!");
        */
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Player != null)
        {

            if (isPaused)
            {
                Resume();
            }
            else
            {
                PauseOn();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //FPScontroller.enabled = true;
        weaponHolder.SetActive(true);
        crosshair.SetActive(true);
        //audiosource.enabled = true;
        isPaused = false;
    }

    void PauseOn()
    {
        Time.timeScale = 0f;
        //FPScontroller.enabled = false;
        weaponHolder.SetActive(false);
        crosshair.SetActive(false);
        //audiosource.enabled = false;
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu");
        Player.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
