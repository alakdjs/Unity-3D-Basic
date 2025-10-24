using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallControl : MonoBehaviour
{
    private GameObject _ballObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // GameObject.Find�� Ȱ��ȭ�Ǿ��ִ� ���ӿ�����Ʈ�� ������� ��
        // ��Ȱ��ȭ �Ǿ��ִ� ���ӿ�����Ʈ�� ã�� ����
        // 1.

        /*
        _ballObj = GameObject.Find("Ball"); // Ball �̶�� ���ӿ�����Ʈ ã��

        // _ballObj.SetActive(false); // _ballObj ���� ������Ʈ�� ��Ȱ��ȭ

        if (_ballObj != null )
        {
            // GetComonent �� ���ӿ�����Ʈ�� �پ��ִ� Component�� ������ ������
            BallScript ballscript = _ballObj.GetComponent<BallScript>();

            ballscript.Go();
        }
        else
        {
            Debug.Log("Ball ������Ʈ�� ã�� ���߽��ϴ�.");
        }
        */

        /*
        // 2.
        // Transform.Find: ���������� �ִ� ������Ʈ ã�� �� ���. ��Ȱ��ȭ�� ������Ʈ�� ã�� �� ����
        Transform ballTr = transform.Find("Ball");
        
        // ballTr.gameObject.SetActive(false);

        if (ballTr != null )
        {
            ballTr.gameObject.SetActive(true);
            ballTr.GetComponent<BallScript>().Go();
            Debug.Log("ball�� ã��");
        }
        else
        {
            Debug.Log("ball�� ã�� ���޽��ϴ�.");
        }
        */

        /*
        // 3. Tag�� ã��
        // var obj = GameObject.FindGameObjectWithTag("RollBall");
        // obj?.GetComponent<BallScript>().Go(); // null�� �ƴϸ� Go() ȣ��

        var objs = GameObject.FindGameObjectsWithTag("RollBall");

        foreach (var ob in objs)
        {
            ob.GetComponent<BallScript>().Go();
        }
        */

        // 4. ������ ã��
        var tr = transform.GetChild(3);
        tr.GetComponent<BallScript>().Go();

        // 5. ������Ʈ type���� ã��
        var ballScript = GameObject.FindFirstObjectByType<BallScript>(); // ��ü�� ���
        ballScript.Go();

        var ballScriptTr = Transform.FindFirstObjectByType<BallScript>(); // ���������� �ִ� ������Ʈ

        var ballScripts = GameObject.FindFirstObjectsByType<BallScript>(); // BallScript ������Ʈ�� ������ �ִ� ��� ������Ʈ

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
