using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 10.0f;
    [SerializeField] private Transform _equipPos;
    [SerializeField] private GameObject[] _weaponsPrefabs;

    private Animator _animator;
    private Transform _cameraTransform;

    private StateMachine _stateMachine;
    private PlayerIdleState _idleState;
    private PlayerMoveState _moveState;
    private PlayerDeadState _deadState;
    private PlayerBasicAttackState _basicAttackState;

    private Rigidbody _rb;

    public StateMachine StateMachine => _stateMachine;
    public PlayerIdleState IdleState => _idleState;
    public PlayerMoveState MoveState => _moveState;
    public PlayerDeadState DeadState => _deadState;
    public PlayerBasicAttackState BasicAttackState => _basicAttackState;

    public Rigidbody Rigidbody => _rb;
    public Animator Animator => _animator;

    private Transform _weapon;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }

        if (_cameraTransform == null)
        {
            _cameraTransform = Camera.main.transform;
        }

        _stateMachine = new StateMachine();
        _idleState = new PlayerIdleState(this);
        _moveState = new PlayerMoveState(this);
        _deadState = new PlayerDeadState(this);
        _basicAttackState = new PlayerBasicAttackState(this);
    }
    void Start()
    {
        _stateMachine.ChangeState(_idleState);
    }

    private void Equipment()
    {
        if (_weapon == null)
        {
            Debug.Log("무기확인");
            _weapon = Instantiate(_weaponsPrefabs[0], _equipPos.position, Quaternion.identity, _equipPos).transform;
        }
        /*
        else if (_weapon != null)
        {
            if (_weapon.name == "StickBase")
            {
                Destroy(_weapon.gameObject);
                _weapon = Instantiate(_weaponsPrefabs[1], _equipPos.position, Quaternion.identity, _equipPos).transform;
            }
            else
            {
                Destroy(_weapon.gameObject);
                _weapon = Instantiate(_weaponsPrefabs[0], _equipPos.position, Quaternion.identity, _equipPos).transform;
            }
        }
        */
    }

    private void CheckEquipment()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Equipment();
        }
    }

    public void CheckDead()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            _stateMachine.ChangeState(_deadState);
        }
    }

    public bool GetBaseAttackInput()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public Vector2 GetMoveInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertial = Input.GetAxis("Vertical");

        return new Vector2(horizontal, vertial).normalized;
    }

    public void Move(Vector2 input)
    {
        if (input.magnitude < 0.01f)
        {
            _rb.linearVelocity = new Vector3(0, _rb.linearVelocity.y, 0);
            return;
        }

        //  카메라 기준 이동 방향 계산
        Vector3 forward = _cameraTransform.forward; //  메인카메라의 전방벡터
        Vector3 right = _cameraTransform.right; // 메인 카메라의    right 벡터

        forward.y = 0.0f;
        right.y = 0.0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * input.y + right * input.x).normalized;

        if (moveDirection.sqrMagnitude > 0.1f)
        {
            Vector3 targetVelocity = moveDirection * _moveSpeed;
            _rb.linearVelocity = new Vector3(targetVelocity.x, _rb.linearVelocity.y, targetVelocity.z);
        }
        else
        {
            _rb.linearVelocity = new Vector3(0, _rb.linearVelocity.y, 0);
        }

        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

    }


    // Update is called once per frame
    void Update()
    {
        CheckEquipment();

        _stateMachine.Update();
    }
}
