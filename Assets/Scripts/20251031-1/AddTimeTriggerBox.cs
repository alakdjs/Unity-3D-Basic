using UnityEngine;

public class AddTimeTriggerBox : MonoBehaviour
{
    [SerializeField] private BallGameMain _GamePlay;
    [SerializeField] private float _AddTime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.CompareTo("PlayBall") == 0)
        {
            _GamePlay.AddTime(_AddTime);
            Destroy(gameObject);
        }
    }

}
