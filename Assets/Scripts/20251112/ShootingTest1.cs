using UnityEngine;

public class ShootingTest1 : MonoBehaviour
{
    [SerializeField] private GameObject _Bullet;
    [SerializeField] private Transform _firePos; // 총알 발사 위치

    private float _spendTime = 0.0f;
    private float _lapTime = 0.2f;
    private bool _isFire = false;
    private int _bulletCount = 5;
    private int _shootCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Shoot()
    {
        var bullet = Instantiate(_Bullet, _firePos.position, Quaternion.identity);

        bullet.GetComponent<Bullet>().ShootPos = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_isFire)
            {
                _isFire = true;
            }
        }

        if (_isFire)
        {
            _spendTime += Time.deltaTime;

            if (_spendTime >= _lapTime)
            {
                Shoot();
                _spendTime = 0.0f;
                _shootCount++;

                if (_shootCount >= _bulletCount)
                {
                    _isFire = false;
                    _spendTime = 0.0f;
                    _shootCount = 0;
                }
            }
        }

    }
}
