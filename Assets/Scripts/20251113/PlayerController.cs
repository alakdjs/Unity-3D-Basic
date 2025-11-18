using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 10.0f;
    [SerializeField] private Transform _equipPos;
    [SerializeField] private GameObject[] _weaponsPrefabs;
    [SerializeField] private BoxCollider _ExeHeadCollider;

    private Animator _animator;
    private Transform _cameraTransform;

    private StateMachine _stateMachine;
    private PlayerIdleState _idleState;
    private PlayerMoveState _moveState;
    private PlayerDeadState _deadState;
    private PlayerBasicAttackState _basicAttackState;
    private PlayerLeftPunchAttackState _leftPunchAttackState;
    private PlayerRightPunchAttackState _rightPunchAttackState;


    private Rigidbody _rb;


    public StateMachine StateMachine => _stateMachine;
    public PlayerIdleState IdleState => _idleState;
    public PlayerMoveState MoveState => _moveState;
    public PlayerDeadState DeadState => _deadState;
    public PlayerBasicAttackState BasicAttackState => _basicAttackState;
    public PlayerLeftPunchAttackState LeftPunchAttackState => _leftPunchAttackState;
    public PlayerRightPunchAttackState RightPunchAttackState => _rightPunchAttackState;

    public Rigidbody Rigidbody => _rb;
    public Animator Animator => _animator;

    private Transform _weapon;

    private float _rotSpeed = 200;


    private readonly float _interpolation = 10.0f;
    private readonly float _walkScale = 0.33f;

    private float _currentV = 0.0f;
    private float _currentH = 0.0f;

    // Start is called before the first frame update
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
        _leftPunchAttackState = new PlayerLeftPunchAttackState(this);
        _rightPunchAttackState = new PlayerRightPunchAttackState(this);

    }

    void Start()
    {
        _ExeHeadCollider.enabled = false;

        _stateMachine.ChangeState(_idleState);
    }

    private void Equipment()
    {
        if (_weapon == null)
        {
            _weapon = Instantiate(_weaponsPrefabs[0], _equipPos.position, Quaternion.identity, _equipPos).transform;
        }
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

    public bool GetLeftPunchAttackInput()
    {
        return Input.GetKeyDown(KeyCode.LeftShift);
    }

    public bool GetRightPunchAttackInput()
    {
        return Input.GetKeyDown(KeyCode.RightShift);
    }

    public Vector2 GetMoveInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        horizontal = 0.0f;
        return new Vector2(horizontal, vertical).normalized;
    }

    public void Move2(Vector2 input)
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

    public void Move(Vector2 input)
    {
        // 방향 입력 처리
        float vel = Input.GetAxis("Vertical");  // 수직변화량 (-1 ~ 1)
        float hor = Input.GetAxis("Horizontal"); // 수평 변화량(-1 ~ 1)

        _currentV = Mathf.Lerp(_currentV, vel, Time.deltaTime * _interpolation);
        _currentH = Mathf.Lerp(_currentH, hor, Time.deltaTime * _interpolation);

        transform.position += transform.forward * _currentV * _moveSpeed * Time.deltaTime;
        transform.Rotate(0.0f, _currentH * _rotSpeed * Time.deltaTime, 0.0f);

        /*

      // 수직변화량과 수평변화량에 일정한 값을 곱해서 걷기 애니메이션이 작동하도록
      // 처리
      if (Input.GetKey(KeyCode.LeftShift))
      {
         vel *= _walkScale;
         hor *= _walkScale;
      }


      if (Input.GetKeyDown(KeyCode.Q))
      {
         _animator.SetBool("IsAttack", true);
         _animator.SetInteger(hashAttack, 3);
      }

      if (Input.GetKeyDown(KeyCode.E))
      {
         _animator.SetInteger(hashAttack, 2);
      }

      if (Input.GetKeyDown(KeyCode.Space))
      {
         if (_isAttack) return; // 현재 공격 애니메이션이 진행중이면 공격동작이 끝나기 전까지 다시 플레이 못하도록 한다.

         _isAttack = true;

         _animator.SetInteger(hashAttack, 1);
      }

      Vector3 direction = new Vector3(hor, 0.0f, vel);

      _animator.SetFloat(hashVelocity, direction.magnitude);
        */
    }

    public void StartOneHandAttack()
    {
        Debug.Log("StartOneHandAttack()");
        _ExeHeadCollider.enabled = true;
    }

    public void EndOneHandAttack()
    {
        Debug.Log("EndOneHandAttack()");
        _ExeHeadCollider.enabled = false;
    }


    /*

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Debug.Log("CollisionEnter");
    }
    */

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.CompareTo("Rock") == 0)
        {
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckEquipment();

        _stateMachine.Update();
    }
}
