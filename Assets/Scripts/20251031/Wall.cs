using UnityEngine;

public class Wall : MonoBehaviour
{
    private bool _isRemoving = false;
    private float _lapTime = 2.0f;
    private float _spendTime = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.CompareTo("CannonBall") == 0 && _isRemoving == false)
        {
            _isRemoving = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_isRemoving)
        {
            _spendTime += Time.deltaTime;

            if(_spendTime >= _lapTime)
            {
                Destroy(this.gameObject);
                Debug.Log("적을 처치했습니다!");
            }
        }
    }
}
