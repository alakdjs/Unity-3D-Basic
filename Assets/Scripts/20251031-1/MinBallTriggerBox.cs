using UnityEngine;

public class MinBallTriggerBox : MonoBehaviour
{
    [SerializeField] private BallGameMain _GamePlay;
    [SerializeField] private int _DeleteBallCount = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayBall") == 0)
        {
            _GamePlay.DeleteEnemyBall(_DeleteBallCount, transform.position);

            Destroy(this.gameObject);

        }
    }
}
