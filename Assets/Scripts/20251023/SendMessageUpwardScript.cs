using UnityEngine;

public class SendMessageUpwardScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SendMessageUpwards("Eat"); // 부모쪽 게임오브젝트 방향으로 메세지를 보낼때.
    }

    // Update is called once per frame
    void Update()
    {

    }
}
