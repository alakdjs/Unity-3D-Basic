using UnityEngine;

public class TagetMove : MonoBehaviour
{
    [SerializeField] private Transform _playerTr;
    [SerializeField] private float _speed = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void EnemyMove()
    {
        Vector3 directVec = _playerTr.position - transform.position;

        directVec = directVec.normalized;

        transform.position += directVec * _speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }
}
