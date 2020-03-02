using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public float health = 2;
    public float stepCoolDown;

    //public GameObject loseMenuUI, winMenuUI;

    public CharacterController controller;

    public AudioSource walkAudio;

    //private bool _isWalking;

    void Start()
    {
        //_isWalking = false;
        //loseMenuUI.SetActive(false);
        //winMenuUI.SetActive(false);
    }
    void Update()
    {
        stepCoolDown -= Time.deltaTime;
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f)
        {
            walkAudio.volume = Random.Range(0.8f, 1);
            walkAudio.pitch = Random.Range(0.8f, 1.1f);
            walkAudio.Play();
        }
    }
    void FixedUpdate()
    {
        Movement();
    }
    
    void Movement()
    {
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //this will move the player based on the direction they are facing
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "PickUp")
        {
            if(Input.GetKey(KeyCode.E) || Input.GetButtonDown("Fire2"))
            {
                Destroy(other.gameObject);
                //winMenuUI.SetActive(true);
                //Time.timeScale = 0f;
                Cursor.visible = true;
                SceneManager.LoadScene("WinScene");
                Debug.Log("Macguffin Get!");
            }

        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Debug.Log("Dead");
            Die();
        }
    }

    void Die()
    {
        //loseMenuUI.SetActive(true);
        //Time.timeScale = 0f;
        Cursor.visible = true;
        SceneManager.LoadScene("LoseScene");
    }
}
