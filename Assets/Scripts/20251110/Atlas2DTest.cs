using UnityEngine;
using UnityEngine.U2D;
using System.Collections;
using System.Collections.Generic;

public class Atlas2DTest : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    private Sprite[] _walksSprites;
    private Sprite[] _idleSprites;
    private Sprite[] _attackSprites;

    private SpriteAtlas _spriteAtlas;

    private int _animIndex = 0;
    private float _nextFrameTime = 0.1f;
    private float _spendTime = 0.0f;

    private bool _dir = true;
    private float _walkSpeed = 2.0f;
    private PlayerState _currentState = PlayerState.Walk;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spriteAtlas = Resources.Load<SpriteAtlas>("Atlas/KnightAtlas");

        _walksSprites = new Sprite[6];
        LoadAtlasSprite(_walksSprites, "Knight_walk", 6);

        _attackSprites = new Sprite[6];
        LoadAtlasSprite(_attackSprites, "Knight_attack", 6);

        _idleSprites = new Sprite[6];
        LoadAtlasSprite(_idleSprites, "Knight_idle", 6);

        _renderer.sprite = _walksSprites[_animIndex];
    }

    private void LoadAtlasSprite(Sprite[] sprites, string name, int count)
    {
        for(int i = 0; i < count; i++)
        {
            string fileName = string.Format("{0}_{1:D2}", name, i + 1);
            Debug.Log($"filename = {fileName}");
            sprites[i] = _spriteAtlas.GetSprite(fileName);
        }
    }

    void Walk()
    {
        _renderer.flipX = _dir;

        if (_spendTime >= _nextFrameTime)
        {
            _spendTime = 0.0f;
            _animIndex++;

            if (_animIndex >= _walksSprites.Length)
            {
                _animIndex = 0;
            }

            _renderer.sprite = _walksSprites[_animIndex++];
        }

        _spendTime += Time.deltaTime;
    }

    void Idle()
    {
        if (_spendTime >= _nextFrameTime)
        {
            _spendTime = 0.0f;

            if (_animIndex >= _idleSprites.Length)
            {
                _animIndex = 0;
            }

            _renderer.sprite = _idleSprites[_animIndex++];
        }

        _spendTime += Time.deltaTime;
    }

    void Attack()
    {
        if (_spendTime >= _nextFrameTime)
        {
            _spendTime = 0.0f;

            if (_animIndex >= _attackSprites.Length)
            {
                _animIndex = 0;
            }

            _renderer.sprite = _attackSprites[_animIndex++];
        }

        _spendTime += Time.deltaTime;
    }


    // Update is called once per frame
    void Update()
    {
        float xmove = Input.GetAxis("Horizontal");

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
        }

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
            if (_currentState != PlayerState.Attack)
            {
                _currentState = PlayerState.Idle;
            }
        }    

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentState == PlayerState.Attack) return;

            _animIndex = 0;

            _currentState = PlayerState.Attack;
        }
    }
}
