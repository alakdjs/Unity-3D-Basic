using UnityEngine;
using System.Threading;

public class ThreadTest : MonoBehaviour
{
    private Thread _thread1;

    private float _spendTime = 0.0f;
    private float _lapTime = 0.02f;

    int _count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _thread1 = new Thread(RunThread);
        _thread1.Start();
        Debug.Log("-------------------------------- End ---------------------------------");
    }

    private void OnDisable()
    {
        _thread1.Abort();
    }

    private void RunThread()
    {
        int count = 0;

        while (true)
        {
            string str = "Test_" + count++;
            Debug.Log($"++++++++++++++++++++++++++++++++++++++++ RunThread {count}");

            Thread.Sleep(10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _spendTime += Time.deltaTime;

        if ( _spendTime >= _lapTime )
        {
            Debug.Log($"----------------------------------- Update {_count}");

            _count++;
            _spendTime = 0.0f;
        }

    }
}
