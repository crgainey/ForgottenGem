using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

    public float damage = 1;
    public float range = 5f;

    public GameObject shotPoint;
    public ParticleSystem flash;

    public AudioSource bangAudio;

    EnemyAI _enemyAI;
    StunEnemy _stunEnemy;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    void Update()
    {
        
    }

    public void Shoot()
    {
        //Debug.Log("PewPew");
        RaycastHit hit;
        if(Physics.Raycast(shotPoint.transform.position, shotPoint.transform.forward, out hit, range)) //checks if we hit something
        {
            Debug.Log(hit.transform.name);
            PlayerController player = hit.transform.GetComponent<PlayerController>();
            if(player != null)
            {
                flash.Play();
                player.TakeDamage(damage);
                bangAudio.Play();
            } 
        }

    }
}
