using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // To fix:
    //if enemy sees player first, able to go back to roam after player moves away.
    //if enemy goes roam and then see player, doesnt chase

    private Vector3 startPos;
    private Vector3 roamPos;

    public float range = 10f;

    NavMeshAgent nav;
    Transform player;

    private static Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private Vector3 GetRandomRoamPos()
    {
        return startPos + GetRandomDir() * Random.Range(10f, 70f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void FacePlayer()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = Brian.instance.player.transform;

        startPos = transform.position;
        roamPos = GetRandomRoamPos();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceaway = Vector3.Distance(player.position, startPos);
        float distanceFromPosReached = 1f;

        if (distanceaway < range)
        {
            nav.SetDestination(player.position);

            if (distanceaway < nav.stoppingDistance)
            {

            }
        }
        else
        {
            nav.SetDestination(roamPos);

            if (Vector3.Distance(transform.position, roamPos) < distanceFromPosReached)
                roamPos = GetRandomRoamPos();
        }
    }
}
