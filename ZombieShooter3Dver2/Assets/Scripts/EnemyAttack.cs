using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool ZG_a_r = false;
    public GameObject player;
    public Animator animator;
    public float damage = 2f;
    public float attackTime = 2f;
    private bool playerAlife;
    //private bool isReacting;

    public AudioSource audioSource;
    public AudioClip attackSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //isReacting = transform.parent.parent.GetComponent<Target>().isReacting;
        //playerAlife = player.GetComponent<PlayerHealth>().isAlife;
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAlife = player.GetComponent<PlayerHealth>().isAlife;
    }
    
    void OnTriggerEnter(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject == player)
        {
            ZG_a_r = true;
            //Debug.Log("Entered in Zombiegirl`s attack range");
            //Debug.Log("ZG_a_r: " + ZG_a_r);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isReacting", false);
            animator.SetBool("isAttacking", true);

            if (playerAlife == true)
            {
                StartCoroutine(DamagePlayer());
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject == player)
        {
            //Debug.Log("Still in Zombiegirl`s attack range");
            //Debug.Log("ZG_a_r: " + ZG_a_r);
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject == player)
        {
            ZG_a_r = false;
            //Debug.Log("Quit from Zombiegirl`s attack range");
            //Debug.Log("ZG_a_r: " + ZG_a_r);
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", false);
        }
    }

    IEnumerator DamagePlayer()
    {
        while (ZG_a_r)
        {
            yield return new WaitForSeconds(attackTime);
            audioSource.clip = attackSound;
            audioSource.Play();
            player.GetComponent<PlayerHealth>().DamagePlayer(damage);

        }
    }

}
