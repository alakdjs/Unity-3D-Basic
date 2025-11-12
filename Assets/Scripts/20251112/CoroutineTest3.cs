using System.Collections;
using UnityEngine;

public class CoroutineTest3 : MonoBehaviour
{
    float _spendTime = 0.0f;
    float _lapTime = 0.02f;
    int _count = 0;

    bool _isStop = false;



    Coroutine _coroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("--------------- Start ----------------------");

        StartCoroutine(RunCoroutine2());

        //_coroutine = StartCoroutine(RunCoroutine());

        //StopCoroutine(_coroutine); // 코루틴을 종료할때 사용.

        //StopAllCoroutines(); // 모든 코루틴을 종료할때 사용
    }

    IEnumerator SubCoroutine()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log($"SubCoroutine i = {i}");
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator RunCoroutine()
    {
        int count = 0;

        while (true)
        {
            //yield return new WaitForSeconds(0.01f); // 게임 시간 0.01초 대기, time Scale 영향을 받음

            //yield return null;  //  한프레임대기

            //yield return new WaitForSecondsRealtime(1.0f); //  실제시간 1초동안 대기

            yield return new WaitForFixedUpdate();  //  다음 FixedUpdate가 끝날때 까지 대기
            /*
            yield return new WaitForEndOfFrame();   // 다음 frame의 Update와 모든 렌더링이 끝날때 까지 대기
            yield return new StartCouroutine(코루틴); //  괄호안에 코루틴이 끝나면 호출
            */

            Debug.Log($"+++++++++++++++++++++++++++  RunCoroutineTest3 = {count} ++");
            count++;
        }
    }

    IEnumerator RunCoroutine2()
    {
        yield return StartCoroutine(SubCoroutine()); // 괄호 안에 코루틴이 끝나면 호출

        _isStop = true;
        Debug.Log($"+++++++++++++++++++++++++++  RunCoroutine2() Complete ++");

    }

    // Update is called once per frame
    void Update()
    {
        if (!_isStop)
        {
            _spendTime += Time.deltaTime;

            if (_spendTime >= _lapTime)
            {
                Debug.Log($"-------------------------- Update {_count} --");
                _count++;
                _spendTime = 0.0f;
            }

        }
    }
}
