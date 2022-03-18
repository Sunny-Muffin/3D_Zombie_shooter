using UnityEngine;
using UnityEngine.UI;

public class Knife : MonoBehaviour
{
    // Variables
    public float damage = 50f;
    public float range = 5f;
    public float impactForce = 30f;
    public float cdAttackTime = 1f;
    private float nextAttackTime = 0f;

    // Game Objects
    public Camera fpsCam;
    public GameObject impactEffect;
    public GameObject bloodEffect;
    public Animator animator;

    // Audio
    public AudioSource _audioSource;
    public AudioClip hitSound;
    public AudioClip swingSound;
    public AudioClip hitEnemySound;

    // Text
    public Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateAmmoText();
    }

    private void OnEnable()
    {
        UpdateAmmoText();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetBool("Attack", (Input.GetButton("Fire1")));
                Attack();
                //PlaySwingSound();
                nextAttackTime = Time.time + cdAttackTime;
            }
        }
        else
            animator.SetBool("Attack", false);
    }


    private void Attack()
    {
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
                PlayHitEnemySound();
                GameObject impactGO = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
            }
            else
            {
                PlayHitSound();
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
            }

            /*
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
            */
            
        }
        else
            PlaySwingSound();

    }

    private void PlayHitSound()
    {
        _audioSource.clip = hitSound;
        _audioSource.Play();
        //Debug.Log("HIT WALL!!");
    }

    private void PlaySwingSound()
    {
        _audioSource.clip = swingSound;
        _audioSource.Play();
        //Debug.Log("SHOOOOHHH!!");
    }

    private void PlayHitEnemySound ()
    {
        _audioSource.clip = hitEnemySound;
        _audioSource.Play();
        //Debug.Log("HIT ENEMY!!");
    }

    private void UpdateAmmoText()
    {
        ammoText.text = "  ";
        // Add ICONS
    }
}
