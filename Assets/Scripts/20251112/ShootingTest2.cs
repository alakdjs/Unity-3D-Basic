using System.Collections;
using UnityEngine;

public class ShootingTest2 : MonoBehaviour
{
    [SerializeField] private GameObject _Bullet;
    [SerializeField] private Transform _firePos;

    private bool _isFire = false;
    private int _bulletCount = 5;
    private float _fireTime = 0.3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Shoot()
    {
        var bullet = Instantiate(_Bullet, _firePos.position, Quaternion.identity);

        bullet.GetComponent<Bullet>().ShootPos = this.transform;
    }

    IEnumerator ShootBullet(float shootTime)
    {
        int count = _bulletCount;

        while (count-- > 0)
        {
            Debug.Log("Fireing --------");
            yield return new WaitForSeconds(shootTime);

            Shoot();
        }

        _isFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_isFire)
            {
                _isFire = true;
                StartCoroutine(ShootBullet(_fireTime));
                Debug.Log("Fire Start -------------------------------");
            }
        }

    }
}
