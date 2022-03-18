using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour
{
    // Vriables
    public int selectedWeapon = 0;

    // Audio
    public AudioSource _audioSource;
    public AudioClip pistolSwap;
    public AudioClip rifleSwap;
    public AudioClip knifeSwap;

    //Icons
    public GameObject gunIcon;
    public GameObject pistolIcon;
    public GameObject knifeIcon;



    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        // code below changes weapons by wheel scrolling
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }
        // code below changes weapons by numbers
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);

                // code below plays sound effects on different weapons & shows their icons
                // костыли конечно те еще, выглядит плохо, но работает, можно было бы реализовать через массив
                if (selectedWeapon == 0)
                {
                    _audioSource.clip = knifeSwap;
                    _audioSource.Play();
                    knifeIcon.gameObject.SetActive(true);
                    pistolIcon.gameObject.SetActive(false);
                    gunIcon.gameObject.SetActive(false);
                }
                if (selectedWeapon == 1)
                {
                    _audioSource.clip = pistolSwap;
                    _audioSource.Play();
                    knifeIcon.gameObject.SetActive(false);
                    pistolIcon.gameObject.SetActive(true);
                    gunIcon.gameObject.SetActive(false);
                }
                if (selectedWeapon == 2)
                {
                    _audioSource.clip = rifleSwap;
                    _audioSource.Play();
                    knifeIcon.gameObject.SetActive(false);
                    pistolIcon.gameObject.SetActive(false);
                    gunIcon.gameObject.SetActive(true);
                }
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }


}
