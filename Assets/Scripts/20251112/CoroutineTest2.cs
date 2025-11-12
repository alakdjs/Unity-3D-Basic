using System.Collections;
using UnityEngine;

public class CoroutineTest2 : MonoBehaviour
{
    IEnumerator _testIEnumerator;

    float _spendTime = 0.0f;
    float _lapTime = 1.0f;
    int _count = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _testIEnumerator = TestIEnumerator();
    }

    IEnumerator TestIEnumerator()
    {
        Debug.Log("첫번째 반환: ");
        yield return 1;

        Debug.Log("두번째 반환: ");
        yield return 2;

        Debug.Log("세번째 반환: ");
        yield return 3;

        Debug.Log("반환 끝");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _testIEnumerator.MoveNext();

            Debug.Log($"Current = {_testIEnumerator.Current}");
        }

        _spendTime += Time.deltaTime;

        if (_spendTime > _lapTime )
        {
            Debug.Log($"----------------------- Update = {_count++} -----------------------");
            _spendTime = 0.0f;
        }

    }
}
