using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StunEnemy : MonoBehaviour
{
    public float stunTime = 3.0f;
    private Hack hack;

    NavMeshAgent _agent;


    void Start()
    {
        GameObject enemy = GameObject.FindWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
        if (enemy == null)
        {
            Debug.Log("Cannot find Player");
        }
        else
        {
            hack = enemy.GetComponent<Hack>();

        }

    }

   

    public void Hacked()
    {
        _agent.enabled = false;
        
        StartCoroutine(StunEnd());

        //disable the enemy for 3 seconds
        //Debug.Log("Hacked");
        //if stunned will stop
        if (hack.isStun)
        {
            return;
        }


    }

    IEnumerator StunEnd()
    {
        //stops movement and waits till end of time to move again
        yield return new WaitForSeconds(stunTime);
        hack.isStun = false;
        _agent.enabled = true;

    }
}
