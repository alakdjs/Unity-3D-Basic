using System.Collections;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    private float _lapTime = 0.2f;
    private float _spendTime = 0.0f;
    private bool _isFinished = false;

    IEnumerator _funcCouroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        int count = 0;

        IEnumerator runCouroutine = RunCoroutine();

        runCouroutine.MoveNext();
        count++;
        Debug.Log($"Start {count}, Current =  {runCouroutine.Current}");

        runCouroutine.MoveNext();
        count++;
        Debug.Log($"Start {count}, Current =  {runCouroutine.Current}");

        runCouroutine.MoveNext();
        count++;
        Debug.Log($"Start {count}, Current =  {runCouroutine.Current}");

        runCouroutine.MoveNext();
        count++;
        Debug.Log($"Start {count}, Current =  {runCouroutine.Current}");

        runCouroutine.MoveNext();
        count++;
        Debug.Log($"Start {count}, Current =  {runCouroutine.Current}");
        */

        /*
        Func();
        */
    }

    IEnumerator RunCoroutine()
    {
        int count = 0;
        yield return 1; // yield¥¬ Ω««‡¿ª ∏ÿ√„.
        count++;
        Debug.Log($"RunCoroutine -- {count}");

        yield return 2;
        count++;
        Debug.Log($"RunCoroutine -- {count}");

        yield return 3;
        count++;
        Debug.Log($"RunCoroutine -- {count}");

        yield return 4;
        count++;
        Debug.Log($"RunCoroutine -- {count}");

        yield return 5;
        count++;
        Debug.Log($"RunCoroutine -- {count}");
    }

    IEnumerator Func2()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log("$Func2 i = {i}");
            yield return i;
        }
    }

    void Func()
    {
        for(int i = 0; i < 100; i++)
        {
            Debug.Log($"i = {i}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isFinished)
        {
            if(_spendTime >= _lapTime)
            {
                _isFinished = !_funcCouroutine.MoveNext();

                var value = _funcCouroutine.Current;
                Debug.Log($"Current = {value}");
            }
        }

    }
}
