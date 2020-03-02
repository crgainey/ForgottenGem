using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack : MonoBehaviour
{
    public float range = 10f;
    public GameObject hackPoint;
    public AudioSource hackAudio;

    public bool isStun = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Hacking();
        }

    }

    public void Hacking()
    {
        RaycastHit hit;
        if (Physics.Raycast(hackPoint.transform.position, hackPoint.transform.forward, out hit, range)) //checks if we hit something
        {
            Debug.Log(hit.transform.name);
            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
            StunEnemy stun = hit.transform.GetComponent<StunEnemy>();
            //or change this to a compare tag and we can hack certain tags
            if (enemy != null)
            {
                //Debug.Log("Hacked");
                isStun = true;
                stun.Hacked();
                //play audio
            }
        }
    }
}
