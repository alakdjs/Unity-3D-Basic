using UnityEngine;

public class EnemyBall : MonoBehaviour
{
    private BallGameMain _GamePlay;

    public void StartDestroy()
    {
        Invoke("Dead", 1.2f);
    }

    
    public void SetGamePlay(BallGameMain gamePlay)
    {
        _GamePlay = gamePlay;
    }
    

    public void Stop()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.enabled = false;
    }

    public void Dead()
    {
        _GamePlay.DecreaseDead();
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        // ¶¥¿¡¼­ ¶³¾îÁø enemyBall Ã³¸®
        if (this.transform.position.y <= 0.0f)
        {
            _GamePlay.DecreaseDead();
            Destroy(this.gameObject);
        }
    }

}
