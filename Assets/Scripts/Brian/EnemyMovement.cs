using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //make distance reach smaller
    private Vector3 startPos;
    private Vector3 roamPos;

    NavMeshAgent nav;
    Transform player;
    EnemyStates states;

    float invisibleCoolDown = 1f;

    private static Vector3 GetRandomDir()
    {
        //Random direction for x or z axis
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private Vector3 GetRandomRoamPos()
    {
        //Random pos given needs to be within NavMesh if not AI will not go to locale
        return startPos + GetRandomDir() * Random.Range(-50f, 50f);
    }

    void OnDrawGizmosSelected()
    {
        //To see enemy range for testing
        Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, range);
    }

    void FacePlayer()
    {
        //face player
        Vector3 dir = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, dir.y, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        states = GetComponent<EnemyStates>();
        player = Manager.instance.Player.transform;
        startPos = transform.position;
        roamPos = GetRandomRoamPos();
        //Debug.Log(GetRandomRoamPos());
    }

    // Update is called once per frame
    void Update()
    {
        float distanceaway = Vector3.Distance(player.position, transform.position);
        float distanceFromPosReached = 10f;
        invisibleCoolDown -= Time.deltaTime;
        Debug.Log(invisibleCoolDown);

        if (states.currState == States.state_roam)
        {
            nav.speed = 2f;
            nav.SetDestination(roamPos);

            //Debug.Log(Vector3.Distance(roamPos, transform.position));
            if (Vector3.Distance(roamPos, transform.position) < distanceFromPosReached)
            {
                roamPos = GetRandomRoamPos();
                Debug.Log(GetRandomRoamPos());
            }
        }
        if (states.currState == States.state_chase)
        {
            nav.speed = 5f;
            nav.SetDestination(player.position);

            //gameObject.GetComponent<Renderer>().enabled = false;
            //gameObject.GetComponentInChildren<Canvas>().enabled = false;

            if (distanceaway < nav.stoppingDistance)
            {
                FacePlayer();
            }
        }
        if (states.currState == States.state_shoot)
        {
            FacePlayer();

            nav.speed = 3f;

            Vector3 moveDir = transform.position - player.transform.position;

            if (Vector3.Distance(player.position, moveDir) < states.range)
                nav.SetDestination(moveDir);
        }
        if (states.currState == States.state_stalk)
        {
            nav.speed = 1f;
            nav.SetDestination(player.position);

            if (invisibleCoolDown <= 0f)
            {
                Debug.Log("TEST");
                if (gameObject.GetComponent<Renderer>().enabled)
                {
                    Debug.Log("TEST1");
                    gameObject.GetComponent<Renderer>().enabled = false;
                    gameObject.GetComponentInChildren<Canvas>().enabled = false;
                    invisibleCoolDown = 1f;
                }
                else
                {
                    Debug.Log("TEST2");
                    gameObject.GetComponent<Renderer>().enabled = true;
                    gameObject.GetComponentInChildren<Canvas>().enabled = true;
                    invisibleCoolDown = 1f;
                }
            }

            if (distanceaway < nav.stoppingDistance)
            {
                FacePlayer();
            }
        }
    }
}
