using UnityEngine;

public class RockTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] _DropLocks;
    [SerializeField] private Camera _mainCamera;

    Vector3 changeCameraPos = new Vector3(-12.0f, 30f, 18f);
    Vector3 changeRotate = new Vector3(90.0f, 0.0f, 0.0f);

    Vector3 originCameraPos;
    Vector3 originCameraRotate;

    void Start()
    {
        originCameraPos = _mainCamera.transform.position;
        originCameraRotate = _mainCamera.transform.eulerAngles;

        this.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Contains("Tank"))
        {
            Camera.main.GetComponent<CameraMove>().Stop(true);
            _mainCamera.transform.position = changeCameraPos;
            _mainCamera.transform.rotation = Quaternion.Euler(changeRotate);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag.Contains("Tank"))
        {
            foreach(var obj in _DropLocks)
            {
                //obj.GetComponent<Rigidbody>().useGravity = true;
                obj.GetComponent<HeavyRock>().Drop();
            }
        }

        Invoke("changeOriginCamera", 2.0f);
    }

    void changeOriginCamera()
    {
        Camera.main.GetComponent<CameraMove>().Stop(false);
        _mainCamera.transform.position = originCameraPos;
        _mainCamera.transform.rotation = Quaternion.Euler(originCameraRotate);
    }

    void Update()
    {
        
    }
}
