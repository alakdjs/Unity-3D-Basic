using UnityEngine;

public enum ShootDirection
{
    Up,
    Down,
    Right,
    Left
}

public class Bullet2 : MonoBehaviour
{
    private float _speed = 3.0f;
    private Transform _shootPos;

    private float _distance = 5.0f;

    private ShootDirection _shootDirection = ShootDirection.Up;

    public Transform ShootPos
    {
        set
        {
            _shootPos = value;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetDirection(ShootDirection direct)
    {
        _shootDirection = direct;
    }


    // Update is called once per frame
    void Update()
    {
        switch (_shootDirection)
        {
            case ShootDirection.Up:
                this.transform.position += transform.forward * _speed * Time.deltaTime;
                break;

            case ShootDirection.Down:
                this.transform.position += -transform.forward * _speed * Time.deltaTime;
                break;

            case ShootDirection.Right:
                this.transform.position += transform.right * _speed * Time.deltaTime;
                break;

            case ShootDirection.Left:
                this.transform.position += -transform.right * _speed * Time.deltaTime;
                break;
        }

        if (Vector3.Distance(_shootPos.position, this.transform.position) > _distance)
        {
            Destroy(this.gameObject);
        }
    }
}
