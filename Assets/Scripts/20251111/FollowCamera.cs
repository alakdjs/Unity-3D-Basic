using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerTr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(_playerTr.position.x, _playerTr.position.y, this.transform.position.z);
    }
}
