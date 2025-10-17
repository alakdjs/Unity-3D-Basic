using UnityEngine;

public enum Direction
{
    Xaxis,
    Yaxis,
    Zaxis
}

public class TrigonalVectorTest : MonoBehaviour
{
    [SerializeField] private Transform _SphereTr;
    [SerializeField] private float _angle = 270.0f;

    private float _distance = 4.0f;

    private float _rotSpeed = 20.0f;

    [SerializeField] private Direction _direction = Direction.Zaxis;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void AngleMoveShpere()
    {
        float xpos = Mathf.Cos(_angle * Mathf.Deg2Rad);
        float ypos = Mathf.Sin(_angle * Mathf.Deg2Rad);

        Vector3 vec = new Vector3(xpos, ypos, 0.0f);

        vec *= _distance;

        _SphereTr.position = vec;
    }

    void RotateSphere()
    {
        _angle += _rotSpeed * Time.deltaTime;

        float xpos = Mathf.Cos(_angle * Mathf.Deg2Rad);
        float ypos = Mathf.Sin(_angle * Mathf.Deg2Rad);

        Vector3 vec = Vector3.zero;

        switch (_direction)
        {
            case Direction.Yaxis:
                vec = new Vector3(xpos, 0.0f, ypos);
                break;
            case Direction.Xaxis:
                vec = new Vector3(0.0f, xpos, ypos);
                break;
            case Direction.Zaxis:
                vec = new Vector3(xpos, ypos, 0.0f);
                break;
        }

        vec = vec.normalized * _distance;

        _SphereTr.position = vec;
    }

    // Update is called once per frame
    void Update()
    {
        // AngleMoveShpere();
        RotateSphere();
    }
}
