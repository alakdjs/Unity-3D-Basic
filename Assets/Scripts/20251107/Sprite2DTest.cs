using Unity.VisualScripting;
using UnityEngine;

enum PlayerState
{
    Walk,
    Idle,
    Attack,
    Defense
};

public class Sprite2DTest : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Sprite[] _walkSprites;
    [SerializeField] private Sprite[] _idleSprites;
    [SerializeField] private Sprite[] _attackSprite;
    [SerializeField] private Sprite[] _defenseSprite;

    private int _animIndex = 0;
    private float _nextFrameTime = 0.1f;
    private float _spendTime = 0.0f;

    private bool _dir = true;
    private float _walkSpeed = 2.0f;

    private PlayerState _currentState = PlayerState.Idle;   // 현재 상태 저장.

    [SerializeField] private BoxCollider _LeftAttackCollider; // 공격시 충돌 처리용 Collider
    [SerializeField] private BoxCollider _RightAttackCollider; // 공격시 충돌 처리용 Collider
    [SerializeField] private BoxCollider _BlockCollider; // 방어용 Collider

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _renderer.sprite = _walkSprites[_animIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Attack");
    }

    void Walk()
    {
        _renderer.flipX = _dir;

        if(_spendTime >= _nextFrameTime)
        {
            _spendTime = 0.0f;
            _animIndex++;

            if (_animIndex >= _walkSprites.Length)
            {
                _animIndex = 0;
            }

            _renderer.sprite = _walkSprites[_animIndex++];
        }

        _spendTime += Time.deltaTime;
    }

    void Idle()
    {
        if(_spendTime >= _nextFrameTime)
        {
            _spendTime = 0.0f;

            if(_animIndex >= _idleSprites.Length)
            {
                _animIndex = 0;
            }

            _renderer.sprite = _idleSprites[_animIndex++];
        }

        _spendTime += Time.deltaTime;
    }

    void Attack()
    {
        if(_spendTime >= _nextFrameTime)
        {
            _spendTime = 0.0f;

            if(_animIndex >= _attackSprite.Length)
            {
                _animIndex = 0;

                _LeftAttackCollider.enabled = false;
                _RightAttackCollider.enabled = false;

                // Attack 애니메이션이 끝났을때 idle 상태로 변경.
                _currentState = PlayerState.Idle;
            }
            else if (_animIndex == 3)
            {
                if (_dir)
                {
                    _LeftAttackCollider.enabled = true;
                }
                else
                {
                    _RightAttackCollider.enabled = true;
                }
            }

            _renderer.sprite = _attackSprite[_animIndex++];
        }

        _spendTime += Time.deltaTime;
    }

    void Defense()
    {
        if (_spendTime >= _nextFrameTime)
        {
            _spendTime = 0.0f;

            if (_animIndex >= _defenseSprite.Length)
            {
                _animIndex = 0;
                _BlockCollider.enabled = false;

                // Defense 애니메이션이 끝났을때 idle 상태로 변경.
                _currentState = PlayerState.Idle;
            }

            _renderer.sprite = _defenseSprite[_animIndex++];
        }

        _spendTime += Time.deltaTime;
    }

    void Move()
    {
        float xmove = Input.GetAxis("Horizontal"); // -1 ~ 1

        switch (_currentState)
        {
            case PlayerState.Walk:
                Walk();
                this.transform.position += new Vector3(xmove, 0.0f, 0.0f).normalized * _walkSpeed * Time.deltaTime;
                break;

            case PlayerState.Idle:
                Idle();
                break;

            case PlayerState.Attack:
                Attack();
                break;

            case PlayerState.Defense:
                Defense();
                break;
        }

        // 키 입력에 따른 상태 처리
        if (_currentState == PlayerState.Attack || _currentState == PlayerState.Defense) return;
        
        if (xmove < 0.0f)
        {
            _currentState = PlayerState.Walk;
            _dir = true;
        }
        else if (xmove > 0.0f)
        {
            _currentState = PlayerState.Walk;
            _dir = false;
        }
        else 
        {
            if(_currentState != PlayerState.Attack)
            {
                _currentState = PlayerState.Idle;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentState == PlayerState.Attack) return;

            _animIndex = 0;

            _currentState = PlayerState.Attack;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (_currentState == PlayerState.Defense) return;

            _BlockCollider.enabled = true;

            _animIndex = 0;

            _currentState = PlayerState.Defense;
        }
    }
}
