using UnityEngine;

public class Player : MonoBehaviour
{
    float _speed = 10.0f;
    float _rotSpeed = 90.0f;

    private Rigidbody _myRigid;
    private float _movePower = 10.0f;

    [SerializeField] private Transform _destinationTr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _myRigid = GetComponent<Rigidbody>();
    }

    private void PhysicsMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _myRigid.AddForce(Vector3.left * _movePower);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _myRigid.AddForce(Vector3.right * _movePower);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _myRigid.AddForce(Vector3.forward * _movePower);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _myRigid.AddForce(Vector3.back * _movePower);
        }
    }

    void PhysicsMove2()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 vel = new Vector3(moveX, 0.0f, moveZ) * _speed;

        _myRigid.linearVelocity = vel;
    }

    private void PhysicsMove3()
    {
        float moveSpeed = _speed * Time.deltaTime;
        float rotateSpeed = _rotSpeed * Time.deltaTime;

        float front = Input.GetAxis("Vertical");
        float ang = Input.GetAxis("Horizontal");

        _myRigid.position += transform.forward * front * moveSpeed;
        transform.Rotate(Vector3.up * ang * rotateSpeed);
    }

    void PhysicsMove4()
    {
        Vector3 newPos = Vector3.MoveTowards(_myRigid.position, _destinationTr.position, _speed * Time.deltaTime);

        _myRigid.MovePosition(newPos);
    }

    private void AxisProcess()
    {
        float moveSpeed = _speed * Time.deltaTime;
        float rotateSpeed = _rotSpeed * Time.deltaTime;

        // Input.GetAxis() -1 ~ 1

        float front = Input.GetAxisRaw("Vertical"); // -1, 0, 1
        float ang = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.forward * front * moveSpeed);
        transform.Rotate(Vector3.up * ang * rotateSpeed);
    }

    private void FixedUpdate()
    {
        //PhysicsMove2();
        //PhysicsMove3();
        PhysicsMove4();
    }
    // Update is called once per frame
    void Update()
    {
        //AxisProcess();
        //PhysicsMove();
    }
}
