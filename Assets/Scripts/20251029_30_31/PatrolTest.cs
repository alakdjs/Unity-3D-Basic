using UnityEngine;

public class PatrolTest : MonoBehaviour
{
    Vector3 _forwardVec = Vector3.zero;
    Vector3 _endPos = Vector3.zero;
    float _speed = 2.0f;
    Vector3 _startPos;

    bool _once = false;
    bool _isStop = false;

    Vector3 _oldForwardVec = Vector3.zero;

    float _viewAngle = 90.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPos = this.transform.position;
    }

    public void Stop()
    {
        _isStop = true;
    }

    public void Move()
    {
        _isStop = false;
    }

    bool IsBehindCamera()
    {
        Camera cam = Camera.main;

        // 타겟을 카메라 로컬 좌표로 변환
        Vector3 localPos = cam.transform.InverseTransformPoint(this.transform.position);

        float angle = Mathf.Atan2(localPos.x, localPos.z) * Mathf.Rad2Deg;

        angle = Mathf.Abs(angle);

        if(angle <= _viewAngle / 2.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    protected void Update()
    {
        if (!_isStop)
        {
            Debug.Log($"_forwardVec.magnitude = {_forwardVec.magnitude}");
            if(_forwardVec.magnitude <= 0.01f)
            {
                Vector2 vec = Vector2.zero;
                while(true)
                {
                    vec = Random.insideUnitCircle;
                    if(vec.magnitude >= 0.3f)
                    {
                        break;
                    }
                }
                vec *= 10.0f;

                _endPos = new Vector3(_startPos.x + vec.x, 1.0f, _startPos.z + vec.y);

                /*
                Vector3 vec = Vector3.zero;
				while (true)
				{
                    vec = Random.insideUnitSphere;

                    if(vec.magnitude >= 0.3f)
					{
                        break;
					}
				}
                vec *= 7;

                _endPos = vec;
                */
            }

            // Debug.Log($"vec.magnitude = {_forwardVec.magnitude}");
            _forwardVec = _endPos - this.transform.position;
            
            if(_forwardVec != Vector3.zero && _oldForwardVec.normalized != _forwardVec.normalized)
            {
                _oldForwardVec = _forwardVec;
                this.transform.rotation = Quaternion.LookRotation(_forwardVec);
            }

            this.transform.position += _forwardVec.normalized * _speed * Time.deltaTime;
        }

        bool isBehindCam = IsBehindCamera();

        if(!isBehindCam)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }

    }
}
