using UnityEngine;

public class TimeTest : MonoBehaviour
{
    float _speed = 2.0f;

    void Start()
    {
        // Time.timeScale = 0 // 정지, 1: normal, 2: 2배 빠름, 0.5: 반느려짐
        Time.timeScale = 0.5f;
    }

    private void FixedUpdate()
    {
        // FixedUpdate가 호출되고 다시 호출될때까지 소요된 시간.
        Debug.Log($"Time.fixedDeltaTime = {Time.fixedDeltaTime}");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Time.time = {Time.time}"); // 게임이 시작된 후에 소요된 시간

        // Update가 호출되고 다음에 호출될때까지 소요된 시간
        Debug.Log($"Time.deltaTime = {Time.deltaTime}");
        this.transform.position += Vector3.right * _speed * Time.deltaTime;
    }
}
