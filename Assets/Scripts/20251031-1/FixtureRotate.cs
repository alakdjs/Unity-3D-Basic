using UnityEngine;

public class FixtureRotate : MonoBehaviour
{

    private enum RotDirection
    {
        Left,
        Right
    }

    [SerializeField] float _rotSpeed = 60.0f;
    [SerializeField] RotDirection _currentRotDirect = RotDirection.Left;


    void Start()
    {
        
    }

    void Update()
    {
        switch (_currentRotDirect)
        {
            case RotDirection.Left:
                transform.Rotate(transform.up * _rotSpeed * Time.deltaTime);
                break;

            case RotDirection.Right:
                transform.Rotate(transform.up * -_rotSpeed * Time.deltaTime);
                break;
        }
    }
}
