using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _PlayerTr;
    [SerializeField] private Transform _targetPos;

    float _yPos = 0.0f;
    bool _isStop = false;

    void Start()
    {
        _yPos = this.transform.position.y;
    }

    public void Stop(bool isStop)
    {
        _isStop = isStop;
    }

    private void LateUpdate()
    {
        if(!_isStop)
        {
            Vector3 playerPos = _PlayerTr.position;

            Vector3 cameraPos = -_PlayerTr.forward * 6.0f;

            cameraPos.y = 2.0f;

            transform.position = _PlayerTr.position + cameraPos;
            this.transform.LookAt(_targetPos);
        }
    }
    void Update()
    {
        
    }
}
