using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallControl : MonoBehaviour
{
    private GameObject _ballObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // GameObject.Find는 활성화되어있는 게임오브젝트를 대상으로 함
        // 비활성화 되어있는 게임오브젝트는 찾지 못함
        // 1.

        /*
        _ballObj = GameObject.Find("Ball"); // Ball 이라는 게임오브젝트 찾기

        // _ballObj.SetActive(false); // _ballObj 게임 오브젝트를 비활성화

        if (_ballObj != null )
        {
            // GetComonent 는 게임오브젝트에 붙어있는 Component의 참조를 가져옴
            BallScript ballscript = _ballObj.GetComponent<BallScript>();

            ballscript.Go();
        }
        else
        {
            Debug.Log("Ball 오브젝트를 찾기 못했습니다.");
        }
        */

        /*
        // 2.
        // Transform.Find: 계층구조상에 있는 오브젝트 찾을 때 사용. 비활성화된 오브젝트도 찾을 수 있음
        Transform ballTr = transform.Find("Ball");
        
        // ballTr.gameObject.SetActive(false);

        if (ballTr != null )
        {
            ballTr.gameObject.SetActive(true);
            ballTr.GetComponent<BallScript>().Go();
            Debug.Log("ball을 찾음");
        }
        else
        {
            Debug.Log("ball을 찾지 못햇습니다.");
        }
        */

        /*
        // 3. Tag로 찾기
        // var obj = GameObject.FindGameObjectWithTag("RollBall");
        // obj?.GetComponent<BallScript>().Go(); // null이 아니면 Go() 호출

        var objs = GameObject.FindGameObjectsWithTag("RollBall");

        foreach (var ob in objs)
        {
            ob.GetComponent<BallScript>().Go();
        }
        */

        // 4. 순서로 찾기
        var tr = transform.GetChild(3);
        tr.GetComponent<BallScript>().Go();

        // 5. 컴포넌트 type으로 찾기
        var ballScript = GameObject.FindFirstObjectByType<BallScript>(); // 전체가 대상
        ballScript.Go();

        var ballScriptTr = Transform.FindFirstObjectByType<BallScript>(); // 계층구조상 있는 컴포넌트

        var ballScripts = GameObject.FindFirstObjectsByType<BallScript>(); // BallScript 컴포넌트를 가지고 있는 모든 오브젝트

        foreach (var ball in ballScripts)
        {
            ball.Go();
        }

        var ballScriptTrs = Transform.FindObjectsByType<BallScript>(FindObjectsSortMode.None);

        foreach (var ball in ballScriptTrs)
        {
            ball.Go();
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
