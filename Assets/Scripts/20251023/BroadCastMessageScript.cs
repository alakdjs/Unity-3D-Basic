using UnityEngine;

public class BroadCastMessageScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BroadcastMessage("Eat"); // 자식오브젝트 방향으로 메세지 보낼 때 사용.
    }

    // Update is called once per frame
    void Update()
    {

    }
}
