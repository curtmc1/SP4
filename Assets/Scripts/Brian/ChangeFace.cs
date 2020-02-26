using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFace : MonoBehaviour
{
    EnemyStates states;

    private Transform childObj;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponentInParent<EnemyStates>();
    }

    // Update is called once per frame
    void Update()
    {
        if (states.currState == States.state_roam)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
