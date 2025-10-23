using UnityEngine;

public class SendGoMessageTest : MonoBehaviour
{
    float _lapTime = 2.0f;
    float _sendTime = 0.0f;
    bool _onceSendMessageCheck = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_onceSendMessageCheck)
        {
            _sendTime += Time.deltaTime;
            // 2�� ���� ��� �Ŀ� Go Message �� ����

            if (_sendTime > _lapTime)
            {
                BroadcastMessage("Go");
                _onceSendMessageCheck = false;
            }
        }
    }
}
