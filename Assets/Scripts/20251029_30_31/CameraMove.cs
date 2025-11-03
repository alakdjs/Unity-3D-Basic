using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    [SerializeField] private Transform _PlayerTr;
    [SerializeField] private Transform _targetPos;

    float _yPos = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _yPos = this.transform.position.y;
    }

    private void LateUpdate()
    {
        Vector3 playerPos = _PlayerTr.position;

        Vector3 cameraPos = -_PlayerTr.forward * 4.0f;

        cameraPos.y = 3.0f;

        transform.position = _PlayerTr.position + cameraPos;
        this.transform.LookAt(_targetPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
