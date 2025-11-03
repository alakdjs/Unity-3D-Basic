using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private float _speed = 5.0f;
    private float _angle = 0.05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CannonBall OnCollsion Enter");

        if (collision.collider.gameObject.name.Contains("Land"))
        {
            Invoke("Destroy", 1.0f);
        }
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position += transform.forward * _speed * Time.deltaTime;

        // 포탄을 회전 시켜서 전방벡터가 서서히 지면을 향하도록 하여
        // 포물선 운동을 하도록 합니다.
        /*
        Vector3 angle = this.transform.rotation.eulerAngles;

        angle.x += _angle;
        Quaternion rotation = Quaternion.Euler(new Vector3(angle.x, angle.y, angle.z));
        this.transform.rotation = rotation;
        */

        /*
        // 포탄이 지면 밑으로 내려가면 포탄 게임 오브젝트를 제거한다.
        if (this.transform.position.y <= 0.0f)
        {
            // Destroy는 게임오브젝트를 제거할때 사용.
            Destroy(this.gameObject);
        }
        */
    }
}
