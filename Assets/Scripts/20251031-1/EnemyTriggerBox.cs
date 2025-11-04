using UnityEngine;

public class EnemyTriggerBox : MonoBehaviour
{
    [SerializeField] private BallGameMain _GamePlay;
    [SerializeField] private int _CreateBallCount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.CompareTo("PlayBall") == 0)
        {
            _GamePlay.MakeEnemyBall(_CreateBallCount, transform.position);

            Destroy(this.gameObject);

        }
    }
}
