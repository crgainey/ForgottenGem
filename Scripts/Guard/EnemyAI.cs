using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public Transform[] waypoints;
    public Transform player;
    public float radius = 10f;
    public float range = 15f;

    public AudioSource fanAudio;
    public GameObject eyeSight;
    public GameObject target;

    private Hack stun;
    
    int _nextpoint = 0;

    NavMeshAgent _agent;
    EnemyGun _gun;

    

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = GameObject.FindWithTag("Player");

        if (enemy == null)
        {
            Debug.Log("Cannot find Player");
        }
        else
        {
            stun = enemy.GetComponent<Hack>();
        }
        _agent = GetComponent<NavMeshAgent>();
        _gun = GetComponent<EnemyGun>();

        GoToNextPoint();
        fanAudio.Play();

    }


    void GoToNextPoint()
    {
       //Returns if no points are setup
        if (waypoints.Length == 0)
            return;

        //sets path for agent
        _agent.destination = waypoints[_nextpoint].position;

        //cycles thru the wp
        _nextpoint = (_nextpoint + 1) % waypoints.Length;
           
    }

    public void FollowPlayer()
    {
        Debug.Log("Following...");
        _agent.SetDestination(player.transform.position);
        if(stun.isStun == false)
        {
        _gun.Shoot();
        }

    }

    private void Update()
    {
        //chooses the next point when agent is close to current wp
        if (!_agent.pathPending && _agent.remainingDistance < 0.2f)
            GoToNextPoint();

        //if player is a certain distance away follow
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < radius)
        {
            Debug.Log("Distance");
            FollowPlayer();
        }

        RaycastHit hit;
        if(Physics.Raycast(eyeSight.transform.position, eyeSight.transform.forward, out hit, range))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
            if(hit.transform.gameObject == target)
            {
                FollowPlayer();
                Debug.Log("I Hit: " + hit.transform.name);

            }
        }

    }

}
