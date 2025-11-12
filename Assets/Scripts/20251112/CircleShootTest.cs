using UnityEngine;
using System.Collections;

public class CircleShootTest : MonoBehaviour
{
    [SerializeField] private GameObject _Bullet;
    [SerializeField] private Transform _FirePos;

    private float _spendTime = 0.0f;
    private float _lapTime = 0.5f;
    private bool _isFire = false;
    private int _bulletCount = 5;
    private int _shootCount = 0;

    private ShootDirection _currentDirection = ShootDirection.Up;

    Coroutine _coroutine = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _isFire = true;
    }

    private void Shoot(ShootDirection direct)
    {
        var bullet = Instantiate(_Bullet, _FirePos.position, Quaternion.identity);

        bullet.GetComponent<Bullet2>().ShootPos = this.transform;
        bullet.GetComponent<Bullet2>().SetDirection(direct);
    }

    IEnumerator ShootBullet(float shootTime)
    {
        int count = _bulletCount;

        while (count-- > 0)
        {
            yield return new WaitForSeconds(shootTime);
            Shoot(_currentDirection);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_isFire)
            {
                _isFire = false;
            }
        }

        if (_isFire)
        {
            _spendTime += Time.deltaTime;

            if (_spendTime >= _lapTime)
            {
                _coroutine = StartCoroutine(ShootBullet(0.4f));

                Debug.Log($"coroutine = {_coroutine.GetHashCode()}");

                _spendTime = 0.0f;

                if (_currentDirection == ShootDirection.Up)
                {
                    _currentDirection = ShootDirection.Down;
                }
                else if (_currentDirection == ShootDirection.Down)
                {
                    _currentDirection = ShootDirection.Right;
                }
                else if (_currentDirection == ShootDirection.Right)
                {
                    _currentDirection = ShootDirection.Left;
                }
                else
                {
                    _currentDirection = ShootDirection.Up;
                }
            }
        }

    }
}
