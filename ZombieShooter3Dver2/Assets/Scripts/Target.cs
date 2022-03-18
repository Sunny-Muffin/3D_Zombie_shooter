using Pathfinding;
using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;
    public float damageTime = 1f;
    public float deathTime = 4f;
    private bool isAlife;
    //public bool isReacting = false;


    public GameObject zombieCounter;
    public GameObject attackCollider;

    public Animator animator;

    public AudioSource audioSource;
    public AudioClip bodyShot;
    public AudioClip walkSound;
    public AudioClip hitSound;
    public AudioClip deathSound;


    private void Start()
    {
        zombieCounter = GameObject.FindGameObjectWithTag("ZombieCounter");
        audioSource.clip = walkSound;
        audioSource.Play();
        animator.SetBool("isWalking", true);
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isReacting", false);
        animator.SetBool("isDying", false);
        isAlife = true;
    }

    public void TakeDamage (float damage)
    {
        
        health -= damage;
        //audioSource.clip = bodyShot;
        //audioSource.Play();
        this.GetComponent<AIPath>().enabled = false;
        if (health <= 0f && isAlife == true)
        {
            StartCoroutine(Die());
        }
        else if (isAlife == true)
            StartCoroutine(DamageAnimation());
        //Debug.Log(health);
    }

    
    IEnumerator DamageAnimation()
    {
        //isReacting = true;
        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isReacting", true);
        audioSource.clip = hitSound;
        audioSource.Play();
        yield return new WaitForSeconds(damageTime);
        animator.SetBool("isReacting", false);
        animator.SetBool("isWalking", true);
        audioSource.clip = walkSound;
        audioSource.Play();
        if (health > 0)
        {
            GetComponent<AIPath>().enabled = true;
            //isReacting = false;
        }
    }
     

    IEnumerator Die()
    {
        isAlife = false;
        attackCollider.SetActive(false);
        GetComponent<AIPath>().enabled = false;
        zombieCounter.GetComponent<ZombieCounter>().zombiesKilled++;
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isReacting", false);
        animator.SetBool("isDying", true);
        audioSource.clip = deathSound;
        audioSource.Play();
        yield return new WaitForSeconds(deathTime);
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isReacting", false);
        animator.SetBool("isDying", false);
        //zombieCounter.GetComponent<ZombieCounter>().zombiesKilled++;
        Destroy(gameObject);
    }

}
