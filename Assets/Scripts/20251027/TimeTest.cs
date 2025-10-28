using UnityEngine;

public class TimeTest : MonoBehaviour
{
    float _speed = 2.0f;

    void Start()
    {
        // Time.timeScale = 0 // ����, 1: normal, 2: 2�� ����, 0.5: �ݴ�����
        Time.timeScale = 0.5f;
    }

    private void FixedUpdate()
    {
        // FixedUpdate�� ȣ��ǰ� �ٽ� ȣ��ɶ����� �ҿ�� �ð�.
        Debug.Log($"Time.fixedDeltaTime = {Time.fixedDeltaTime}");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Time.time = {Time.time}"); // ������ ���۵� �Ŀ� �ҿ�� �ð�

        // Update�� ȣ��ǰ� ������ ȣ��ɶ����� �ҿ�� �ð�
        Debug.Log($"Time.deltaTime = {Time.deltaTime}");
        this.transform.position += Vector3.right * _speed * Time.deltaTime;
    }
}
