using UnityEngine;

public class PlayerTerrainController : MonoBehaviour
{
    private CharacterController _playerController;

    private Vector3 _direct;
    private float _speed = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("OnControllColliderHit");

    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.isGrounded)
        {
            var hor = Input.GetAxis("Horizontal");
            var ver = Input.GetAxis("Vertical");

            _direct = new Vector3(hor, 0, ver) * _speed;

            if (_direct != Vector3.zero)
            {
                this.transform.rotation = Quaternion.LookRotation(_direct);
            }
        }

        _direct.y += Physics.gravity.y * Time.deltaTime;
        _playerController.Move(_direct * Time.deltaTime);

    }
}
