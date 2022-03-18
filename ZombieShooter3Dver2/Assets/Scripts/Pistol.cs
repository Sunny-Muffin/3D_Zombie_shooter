using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public int maxAmmoInMag = 30;
    public int currentAmmo;
    public int totalAmmo = 120;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject bloodEffect;

    private float nextTimeToFire = 0f;

    public Animator animator;

    //Audio
    public AudioSource _audioSource;
    public AudioClip shootSound;
    public AudioClip reloadSound;

    // Text
    public Text ammoText;

    private void Start()
    {
        currentAmmo = maxAmmoInMag;
        animator = GetComponent<Animator>();
        UpdateAmmoText();
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
        UpdateAmmoText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            animator.SetBool("Shooting", false);
            return;
        }

        if ((currentAmmo <= 0 && totalAmmo > 0) || (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmoInMag && totalAmmo > 0))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            animator.SetBool("Shooting", (Input.GetButton("Fire1")));
            Shoot();
        }
        else
            animator.SetBool("Shooting", false);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        //Debug.Log("Reloading");
        animator.SetBool("Reloading", true);
        PlayReloadSound();
        yield return new WaitForSeconds(reloadTime - 0.25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);

        if (totalAmmo >= maxAmmoInMag)
        {
            totalAmmo = totalAmmo - (maxAmmoInMag - currentAmmo);
            currentAmmo = maxAmmoInMag;
        }
        else
        {
            currentAmmo = totalAmmo;
            totalAmmo = 0;
        }
        UpdateAmmoText();
        isReloading = false;
    }

    void Shoot()
    {
        if (totalAmmo <= 0 && currentAmmo <= 0)
        {
            animator.SetBool("Shooting", false);
            Debug.Log("Click!");
            // TODO FIND CLICK SOUND!
            return;
        }

        muzzleFlash.Play();

        currentAmmo--;
        UpdateAmmoText();
        PlayShootSound();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            if (hit.transform.tag == "Enemy" || hit.transform.tag == "Boss")
            {
                GameObject impactGO = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
            }
            else
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
            }

        }
    }

    private void PlayShootSound()
    {
        _audioSource.clip = shootSound;
        _audioSource.Play();
    }

    private void PlayReloadSound()
    {
        _audioSource.clip = reloadSound;
        _audioSource.Play();
    }

    private void UpdateAmmoText()
    {
        ammoText.text = currentAmmo + " / " + totalAmmo;
    }
}



