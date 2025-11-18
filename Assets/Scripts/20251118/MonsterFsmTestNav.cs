using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterFsmTestNav : MonoBehaviour
{

    public enum State
    {
        Stop,
        Chase,
        Attack,
        Patrol,
        Dead
    }

    private State _currentState = State.Patrol; // 현재 상태

    private bool _isDead = false;   // Monster의 생사여부

    private Transform _targetTr = null; // 타겟 Transform.

    private float _speed = 2.0f;    // 몬스터의 이동 속도

    private float _chaseRange = 10.0f;  // 추적 반경.
    private float _attackRange = 2.0f;  // 공격 반경

    private float _targetDistance = 0.0f;   // 타겟과의 거리.

    private bool _isFirst = true;

    [SerializeField] private Transform _PatrolPosParent;
    [SerializeField] private WayPoint[] _patrolPositions;


    private int _wayPointIndex = 0;
    NavMeshAgent _nmAgent;
    Animator _myAnimator;
    bool _isAttack = false;

    [SerializeField] private WeaponTest _CurrentWeapon;
    [SerializeField] private Transform _WeaponPos;  // 장착될 위치
    [SerializeField] private Transform _Weapon; // 장착할 무기

    // Start is called before the first frame update
    void Start()
    {
        var weapon = Instantiate(_Weapon, _WeaponPos);
        _CurrentWeapon = weapon.GetComponent<WeaponTest>();


        _myAnimator = GetComponent<Animator>();
        _nmAgent = GetComponent<NavMeshAgent>();

        // 패트롤할 WayPoint를 가지고 온다.
        var wayPoints = _PatrolPosParent.GetComponentsInChildren<WayPoint>();

        // wayPoints를 저장할 배열을 할당한다.
        _patrolPositions = new WayPoint[wayPoints.Length];

        _patrolPositions = wayPoints;

        StartCoroutine(FSM());
    }

    private void Stop()
    {
        Debug.Log("Stop");
    }

    private void Chase()
    {
        if (_targetTr != null)
        {
            _myAnimator.SetBool("IsWalk", true);
            _isFirst = true;
            _nmAgent.isStopped = false;
            _nmAgent.SetDestination(_targetTr.position);

            /*
            Vector3 direct = _targetTr.position - this.transform.position;  // 추적할 방향 벡터를 만든다.
            direct.y = 0.0f;

            this.transform.position += direct.normalized * _speed * Time.deltaTime; // 추적 방향으로 이동한다.
            */
        }

    }

    public void OffAttack()
    {
        _isAttack = false;
    }

    private void Attack()
    {
        if (_targetTr != null)
        {
            if (!_isAttack)
            {
                _isAttack = true;
                _myAnimator.SetTrigger("Attack");
                //_targetTr.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }

    }

    private void Patrol()
    {
        _myAnimator.SetBool("IsWalk", true);

        // 다음 정해진 WayPoint에 도착하면
        // 다음 Waypoint로 지정
        //Debug.Log(_nmAgent.destination.magnitude);
        if (!_nmAgent.pathPending)
        {
            if (_nmAgent.remainingDistance <= 0.3f)
            {
                _wayPointIndex++;

                // wayPoint 배열의 마지막이면 처음으로 인덱스값을 조정한다.
                if (_wayPointIndex >= _patrolPositions.Length)
                {
                    _wayPointIndex = 0;
                }

                _nmAgent.SetDestination(_patrolPositions[_wayPointIndex].transform.position);

            }
        }



        if (_isFirst)
        {
            _isFirst = false;
            _nmAgent.SetDestination(_patrolPositions[_wayPointIndex].transform.position);
        }




        // 정해진 반경에 player가 들어왔는지 체크
        Collider[] colliders = Physics.OverlapSphere(transform.position, _chaseRange);

        // 추적반경안에 들어온 오브젝트에  Player가 있는지 체크한다.
        foreach (var col in colliders)
        {
            if (col.gameObject.name.Contains("Player"))
            {
                _targetTr = col.gameObject.transform;

                break;
            }
        }

    }

    public void StartAttack()
    {
        Debug.Log("StartAttack()");
        _CurrentWeapon.TurnOnCollider();
    }

    public void EndAttack()
    {
        Debug.Log("EndAttack()");
        _CurrentWeapon.TurnOffCollider();
    }

    private void Dead()
    {

    }

    IEnumerator FSM()
    {
        while (!_isDead)
        {
            switch (_currentState)
            {
                case State.Stop:
                    //Debug.Log("Stop");
                    Stop();
                    yield return new WaitForSeconds(2.0f);
                    break;

                case State.Chase:
                    _myAnimator.SetBool("IsWalk", true);
                    _nmAgent.isStopped = false;
                    //Debug.Log("Chase");
                    Chase();
                    yield return new WaitForSeconds(0.01f);
                    break;

                case State.Attack:
                    _myAnimator.SetBool("IsWalk", false);
                    _nmAgent.isStopped = true;
                    //Debug.Log("Attack");
                    Attack();
                    yield return new WaitForSeconds(0.2f);
                    //_targetTr.GetComponent<MeshRenderer>().material.color = Color.white;
                    break;

                case State.Patrol:
                    _myAnimator.SetBool("IsWalk", true);
                    _nmAgent.isStopped = false;
                    //Debug.Log("Patrol");
                    Patrol();
                    yield return new WaitForSeconds(0.01f);
                    break;

                case State.Dead:
                    //Debug.Log("Dead");
                    Dead();
                    _isDead = true;

                    break;
            }
        }

        Debug.Log("--- FSM END ---");
    }

    void UpdateState()
    {
        // 타켓이 있고, 공격반경안에 있으면 공격상태로 변경
        if (_targetTr != null && _targetDistance < _attackRange)
        {
            _currentState = State.Attack;
        }
        else if (_targetTr != null && (_targetDistance >= _attackRange && _targetDistance <= _chaseRange))
        {
            // 공격반경 벗어나있으나 추적반경안에 있는 경우
            _currentState = State.Chase;
        }
        else
        {
            _currentState = State.Patrol;
        }

        // 타켓이 있는 경우
        // 타겟과의 거리를 계산한다.
        if (_targetTr != null)
        {

            _targetDistance = Vector3.Distance(_targetTr.position, this.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }
}