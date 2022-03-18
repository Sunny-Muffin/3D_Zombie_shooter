using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Floater : MonoBehaviour
{
    private Rigidbody rb;
    public float floatUpSpeedLimit = 1.5f;
    public float floatUpSpeed = 1f;

    private float walkSpeed;
    private float runSpeed;
    private float jumpSpeed;
    public float underWaterCoef;
    //private bool isUnderWater;
    public float underWaterTime;
    private float secondsLeft;
    public float waterDamage;

    private float waterWalkSpeed;
    private float waterRunSpeed;
    private float waterJumpSpeed;

    public GameObject Player;
    public GameObject WeaponHolder;
    public AudioSource audioSource;
    public AudioClip heartBeat;
    public PlayerHealth playerHealth;

    public Text SecondsUnderWater;

    private Coroutine coroutine;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        walkSpeed = Player.GetComponent<FirstPersonController>().m_WalkSpeed;
        runSpeed = Player.GetComponent<FirstPersonController>().m_RunSpeed;
        jumpSpeed = Player.GetComponent<FirstPersonController>().m_JumpSpeed;
        audioSource.enabled = false;
        //isUnderWater = false;
        secondsLeft = underWaterTime;
        SecondsUnderWater.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 4)
        {
            //Debug.Log("I'm in WATER!!");
            //Debug.Log(rb.name);


            float difference = (other.transform.position.y - transform.position.y) * floatUpSpeed;
            rb.AddForce(new Vector3(0f, Mathf.Clamp((Mathf.Abs(Physics.gravity.y) * difference), 0, Mathf.Abs(Physics.gravity.y) * floatUpSpeedLimit), 0f), ForceMode.Acceleration);
            rb.drag = 0.99f;
            rb.angularDrag = 0.8f;

            Player.GetComponent<FirstPersonController>().m_WalkSpeed = walkSpeed * underWaterCoef;
            Player.GetComponent<FirstPersonController>().m_RunSpeed = runSpeed * underWaterCoef;
            Player.GetComponent<FirstPersonController>().m_JumpSpeed = jumpSpeed * underWaterCoef;

            Player.GetComponent<FirstPersonController>().m_AudioSource.enabled = false;
            WeaponHolder.SetActive(false);
            

            // Death after 20 sec Ienumerator
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            //isUnderWater = true;
            HeartBeat();
            coroutine = StartCoroutine(WaterCounter());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            //isUnderWater = false;
            rb.drag = 0f;
            rb.angularDrag = 0f;
            Player.GetComponent<FirstPersonController>().m_WalkSpeed = walkSpeed;
            Player.GetComponent<FirstPersonController>().m_RunSpeed = runSpeed;
            Player.GetComponent<FirstPersonController>().m_JumpSpeed = jumpSpeed;

            Player.GetComponent<FirstPersonController>().m_AudioSource.enabled = true;
            audioSource.enabled = false;
            WeaponHolder.SetActive(true);

            StopCoroutine(coroutine);
            secondsLeft = underWaterTime;
            SecondsUnderWater.enabled = false;
        }
    }

    void HeartBeat()
    {
        //Debug.Log("Тук-Тук... Тук-Тук");
        audioSource.enabled = true;
        audioSource.clip = heartBeat;
        audioSource.Play();
    }

    IEnumerator WaterCounter()
    {
        while (secondsLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            secondsLeft--;
            // Debug.Log("Осталось " + secondsLeft + "секунд под водой");
            SecondsUnderWater.enabled = true;
            SecondsUnderWater.text = "Need air: " + secondsLeft.ToString();
            // Show text with left seconds
        }
        while (secondsLeft == 0)
        {
            yield return new WaitForSeconds(1f);
            //Debug.Log("ТОНУ!!");
            playerHealth.DamagePlayer(waterDamage);
            //DamagePlayer
        }

        

    }



}
