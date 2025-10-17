using UnityEngine;

public class TrigonalMetricTest : MonoBehaviour
{
    private float _xpos = 0.0f;
    private float _ypos = 0.0f;

    private float _angle = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        _xpos = Mathf.Cos(_angle * Mathf.Deg2Rad);
        _ypos = Mathf.Sin(_angle * Mathf.Deg2Rad);

        Vector3 vec1 = new Vector3(_xpos, _ypos, 0.0f);

        vec1 *= 3.0f;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, vec1);

        _angle += 0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
