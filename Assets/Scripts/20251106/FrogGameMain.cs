using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class FrogGameMain : MonoBehaviour
{
    [SerializeField] private Sprite[] _NumberImages;
    [SerializeField] private Image _CountImage;
    [SerializeField] private Text _ScoreText;

    private int _score;

    // [SerializeField] private Transform _FrogCubeParentTr;

    float _lapTime = 1.0f;
    float _spendTime = 0.0f;

    int _StartCount = 5;
    bool _isStart = false;

    private string[] stageSceneName = { "20251106_Stage1_Scene", "20251106_Stage2_Scene" };

    private int _currentStageNum = 0;

    public static FrogGameMain Instance { get; private set; } //   싱글턴패턴
    
    public Action _stageAction;

    void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _isStart = true;
        _CountImage.gameObject.SetActive(true);
        _CountImage.sprite = _NumberImages[_StartCount];

        _score = 0;

        SceneManager.LoadScene(stageSceneName[_currentStageNum], LoadSceneMode.Additive);
    }

    public void AddScore(int score)
    {
        _score += score;

        if (_ScoreText != null)
        {
            _ScoreText.text = $"Score: {_score}";
        }
    }

    void Init() // 초기화
    {
        _spendTime = 0.0f;
        _StartCount = 5;
        _isStart = true;
        _CountImage.gameObject.SetActive(true);
        _CountImage.sprite = _NumberImages[_StartCount];
    }


    // 숫자 카운트가 완료된 후에 FrogCube가 점프하도록 처리하기
    void StartGame()
    {
        _stageAction();
    }

    public void SetAction(Action action)
    {
        _stageAction = action;
    }

    public void OnClickNextSceneButton()
    {
        NextStage();
    }

    public void OnClickNextScene2Button()
    {
        NextStage();
    }

    public void InvokeNextStage()
    {
        Invoke("NextStage", 1.0f);
    }

    public void PlayGame()
    {
        SceneManager.UnloadSceneAsync(stageSceneName[_currentStageNum]);
        // 씬을 로드
        SceneManager.LoadScene(stageSceneName[_currentStageNum], LoadSceneMode.Additive);

        // 스테이지를 처음부터 스타팅하기위해 초기화
        Init();
    }

    public void NextStage()
    {
        // 이전 Scene은 언로드
        SceneManager.UnloadSceneAsync(stageSceneName[_currentStageNum]);
        _currentStageNum++;

        // 현재 마지막 스테이지면 처음으로 돌린다.
        if (_currentStageNum >= stageSceneName.Length)
        {
            _currentStageNum = 0;
        }

        // 씬을 로드
        SceneManager.LoadScene(stageSceneName[_currentStageNum], LoadSceneMode.Additive);

        // 스테이지를 처음부터 스타팅하기위해 초기화
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart)
        {
            _spendTime += Time.deltaTime;

           // Debug.Log($"_spendTime = {_spendTime}");

            if (_spendTime >= _lapTime)
            {
                if (_StartCount >= 0)
                {
                    _StartCount--;

                    if (_StartCount >= 0)
                    {
                        _CountImage.sprite = _NumberImages[_StartCount];
                    }
                    else
                    {
                        _CountImage.gameObject.SetActive(false);
                    }
                }
                else
                {
                    _isStart = false;
                    StartGame();
                }

                _spendTime = 0.0f;
            } 
        }
    }
}
