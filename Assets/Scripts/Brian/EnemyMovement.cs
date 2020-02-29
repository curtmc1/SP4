using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;

public class EnemyMovement : EnemyMovementBehavior
{
    //make distance reach smaller
    private Vector3 startPos;
    private Vector3 roamPos;

    NavMeshAgent nav;
    Transform player;
    EnemyStates states;

    float invisibleCoolDown = 5f;
    bool invisible = false;

    float distanceaway = 0f;

    public float GetInvisibleCoolDown
    {
        get { return invisibleCoolDown; }
        set { invisibleCoolDown = value;}
    }

    public bool GetInvisible
    {
        get { return invisible; }
        set { invisible = value; }
    }

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
        if (player != null)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, dir.y, dir.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    void TurnInvisible()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        //gameObject.GetComponentInChildren<Canvas>().enabled = false;

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);

        networkObject.SendRpc(RPC_INVISIBLE_OR_NOT, Receivers.AllBuffered, false, false, false, false, false);

        invisibleCoolDown = 5f;
        invisible = true;
    }

    void TurnVisible()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        //gameObject.GetComponentInChildren<Canvas>().enabled = true;

        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
        gameObject.transform.GetChild(3).gameObject.SetActive(true);

        networkObject.SendRpc(RPC_INVISIBLE_OR_NOT, Receivers.AllBuffered, true, true, true, true, true);

        invisibleCoolDown = 1f;
        invisible = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        states = GetComponent<EnemyStates>();
        startPos = transform.position;
        roamPos = GetRandomRoamPos();
        //Debug.Log(GetRandomRoamPos());
    }

    // Update is called once per frame
    void Update()
    {
        if (!networkObject.IsServer) return;

        for (int i = 0; i < Manager.instance.Player.Length; i++)
        {
            float dist = Vector3.Distance(Manager.instance.Player[i].transform.position, transform.position);

            if (dist < 20)
                player = Manager.instance.Player[i].transform;
        }

        if (player != null)
            distanceaway = Vector3.Distance(player.position, transform.position);

        float distanceFromPosReached = 10f;
        invisibleCoolDown -= Time.deltaTime;

        if (states.currState == States.state_roam)
        {
            nav.speed = 2f;
            nav.SetDestination(roamPos);

            //Debug.Log(Vector3.Distance(roamPos, transform.position));
            if (Vector3.Distance(roamPos, transform.position) < distanceFromPosReached)
            {
                roamPos = GetRandomRoamPos();
                //Debug.Log(GetRandomRoamPos());
            }
        }
        if (states.currState == States.state_chase)
        {
            nav.speed = 5f;

            if (player != null)
                nav.SetDestination(player.position);

            if (distanceaway < nav.stoppingDistance)
            {
                FacePlayer();
            }
        }
        if (states.currState == States.state_shoot)
        {
            FacePlayer();

            nav.speed = 7f;

            if (player != null)
            {
                Vector3 moveDir = transform.position - player.transform.position;

                if (Vector3.Distance(player.position, moveDir) < states.range)
                    nav.SetDestination(moveDir);
            }
        }
        if (states.currState == States.state_stalk)
        {
            nav.speed = 3f;

            if (player != null)
                nav.SetDestination(player.position);

            if (invisibleCoolDown <= 0f)
            {
                if (!invisible)
                    TurnInvisible();
                else if (invisible)
                    TurnVisible();
            }

            if (distanceaway < nav.stoppingDistance)
            {
                FacePlayer();
            }
        }
    }

    public override void InvisibleOrNot(RpcArgs args)
    {
        if (networkObject.IsServer) return;

        bool renderer = args.GetNext<bool>();
        bool childZero = args.GetNext<bool>();
        bool childOne = args.GetNext<bool>();
        bool childTwo = args.GetNext<bool>();
        bool childThree = args.GetNext<bool>();

        gameObject.GetComponent<Renderer>().enabled = renderer;

        gameObject.transform.GetChild(0).gameObject.SetActive(childZero);
        gameObject.transform.GetChild(1).gameObject.SetActive(childOne);
        gameObject.transform.GetChild(2).gameObject.SetActive(childTwo);
        gameObject.transform.GetChild(3).gameObject.SetActive(childThree);
    }
}
