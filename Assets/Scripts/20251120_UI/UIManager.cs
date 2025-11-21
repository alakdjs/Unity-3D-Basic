using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIView _InitView;
    [SerializeField] private UIView _GameView;
    [SerializeField] private UIView _EndingView;
    [SerializeField] private UIView _OptionView;
    [SerializeField] private UIView _OptionPopUp;

    private Stack<UIView> _uiStack = new Stack<UIView>(); // UIView 를 저장하기 위한 Stack 자료구조
    private UIView _currentUIView = null;

    private static UIManager _instance;

    public static UIManager Instance
    {
        get => _instance;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Init();
    }

    void Init()
    {
        _InitView.Show();
        _GameView.UnShow();
        _EndingView.UnShow();
        _OptionPopUp.UnShow();

        _currentUIView = _InitView;

    }


    void PushUIView(UIView view, bool isShow = false)
    {
        if (!isShow)
        {
            view.UnShow();
        }
        _uiStack.Push(view);
    }

    void PopUIView()
    {
        if (_uiStack.Count <= 0) return;

        _currentUIView.UnShow();
        _currentUIView = _uiStack.Pop();
        _currentUIView.Show();
    }

    public void ShowGameView()
    {
        PushUIView(_currentUIView);
        _GameView.Show();
        _currentUIView = _GameView;
    }

    public void ShowOptionView()
    {
        PushUIView(_currentUIView);
        _OptionView.Show();
        _currentUIView = _OptionView;
    }

    public void ShowOptionPopUp()
    {
        PushUIView(_currentUIView, true);
        _OptionPopUp.Show();
        _currentUIView = _OptionPopUp;
    }

    public void ShowEndingView()
    {
        PushUIView(_currentUIView);
        _EndingView.Show();
        _currentUIView = _EndingView;
    }

    public void UnShowOptionPopUp()
    {
        PopUIView();
    }

    public void PreUIView()
    {
        PopUIView();
    }


    // Update is called once per frame
    void Update()
    {
        // InitView
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PushUIView(_currentUIView);
            _InitView.Show();
            _currentUIView = _InitView;
        }

        // GameView;
        if (Input.GetKeyDown(KeyCode.W))
        {
            PushUIView(_currentUIView);
            _GameView.Show();
            _currentUIView = _GameView;
        }

        // EndingView
        if (Input.GetKeyDown(KeyCode.E))
        {
            PushUIView(_currentUIView);
            _EndingView.Show();
            _currentUIView = _EndingView;
        }

        // OptionView
        if (Input.GetKeyDown(KeyCode.R))
        {
            PushUIView(_currentUIView);
            _OptionView.Show();
            _currentUIView = _OptionView;
        }

        // OptionPopUp
        if (Input.GetKeyDown(KeyCode.T))
        {
            PushUIView(_currentUIView);
            _OptionPopUp.Show();
            _currentUIView = _OptionPopUp;
        }

        // PrevButton
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PreUIView();
        }

    }
}
