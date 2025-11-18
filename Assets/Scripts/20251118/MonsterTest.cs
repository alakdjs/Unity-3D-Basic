using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class MonsterTest : MonoBehaviour
{
    public Transform _targetObj;
    NavMeshAgent _nmAgent;


    void Start()
    {
        _nmAgent = GetComponent<NavMeshAgent>();
    }

    public void SetTarget(Transform target)
    {
        _targetObj = target;
    }


    void Update()
    {
        if(_targetObj != null)
        {
            Vector3 direct = _targetObj.position - this.transform.position;

            if(direct.magnitude > 1.5f)
            {
                _nmAgent.isStopped = false;
                _nmAgent.SetDestination(_targetObj.position);

            }
            else
            {
                _nmAgent.isStopped = true;
            }
        }

    }
}
