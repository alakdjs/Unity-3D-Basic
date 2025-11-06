using UnityEngine;

public class FrogCube : MonoBehaviour
{
    enum State
    {
        Jump,
        Ground
    }
    enum Type
    {
        UpDown,
        Flying
    }


    private Rigidbody _rb;
    private float _jumpPower = 1.0f;
    State _currentState = State.Jump;

    [SerializeField] private Type _type;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _jumpPower = Random.Range(10.0f, 20.0f);

        // Jump();
    }

    public void Jump()
    {
        switch (_type)
        {
            case Type.UpDown:
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
                break;

            case Type.Flying:
                _rb.AddForce(new Vector3(0.0f, 1.0f, -1.0f).normalized * _jumpPower, ForceMode.Impulse);
                break;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.CompareTo("Land") == 0)
        {
            _currentState = State.Ground;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag.CompareTo("Land") == 0)
        {
            _currentState = State.Jump;
        }
    }

    public void Hit()
    {
        if (_currentState == State.Jump)
        {
            FrogGameMain.Instance.AddScore();

            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
