using UnityEngine;

public class MinTimeTriggerBox : MonoBehaviour
{
    [SerializeField] private BallGameMain _GamePlay;
    [SerializeField] private float _MinTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayBall") == 0)
        {
            _GamePlay.MinTime(_MinTime);
            Destroy(gameObject);
        }
    }

}
