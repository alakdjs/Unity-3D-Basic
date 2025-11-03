using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallGameMain : MonoBehaviour
{
    [SerializeField] private Text _EnemyBallCountText;
    [SerializeField] private Text _GameClearText;
    [SerializeField] private Text _PlayTimeText;
    [SerializeField] private GameObject _EnemyBallPrefab;
    [SerializeField] private Transform _EnemyParent;
    [SerializeField] private EnemyBallControl _EnemyBallCtrl;

    private float _radius = 5.0f;
    private int _ballCount = 20;

    float _lapTime = 100.0f; // 게임 진행시간
    float _spendTime = 0.0f;

    bool _isPlay = false; // 게임 실행 유무

    public bool isPlay
    {
        get => _isPlay;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _PlayTimeText.text = "PlayTime: 0.00f";
        _spendTime = 0.0f;
        MakeEnemyBall(_ballCount);
        _isPlay = true;

        _EnemyBallCountText.text = _ballCount.ToString();
    }

    void MakeEnemyBall(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 createPos = Random.insideUnitCircle * _radius;

            var ball = Instantiate(_EnemyBallPrefab, new Vector3(createPos.x, 2.0f, createPos.y), Quaternion.identity, _EnemyParent);

            ball.GetComponent<EnemyBall>().SetGamePlay(this);
        }
    }

    public void DecreaseDead()
    {
        _ballCount--;

        _EnemyBallCountText.text = _ballCount.ToString();
        
        if(_ballCount <= 0)
        {
            _GameClearText.text = "Game Clear";
            _GameClearText.gameObject.SetActive(true);

            _isPlay = false;
        }
    }

    void GameOver()
    {
        _EnemyBallCtrl.StopAllBalls();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlay)
        {
            _spendTime += Time.deltaTime;
            
            if (_spendTime >= _lapTime)
            {
                GameOver();
                _isPlay = false;
            }
            else
            {
                _PlayTimeText.text = "PlayTime: " + (_lapTime - _spendTime).ToString("0.00");
            }
        }
    }
}
