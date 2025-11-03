using UnityEngine;

public class FixtureMove2 : MonoBehaviour
{
    enum Direction
    {
        Down,
        Up
    }

    [SerializeField] private Transform _FixtureObj;
    [SerializeField] private Transform _UpPosTr;
    [SerializeField] private Transform _DownPosTr;

    private Direction _currentDirect = Direction.Up;

    private float _moveSpeed = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentDirect)
        {
            case Direction.Up:
                _FixtureObj.position += transform.forward.normalized * _moveSpeed * Time.deltaTime;

                if (Vector3.Distance(_FixtureObj.position, _UpPosTr.position) <= 0.01f)
                {
                    _currentDirect = Direction.Down;
                }

                break;

            case Direction.Down:
                _FixtureObj.position -= transform.forward.normalized * _moveSpeed * Time.deltaTime;

                if (Vector3.Distance(_FixtureObj.position, _DownPosTr.position) <= 0.01f)
                {
                    _currentDirect = Direction.Up;
                }

                break;
        }

    }
}
