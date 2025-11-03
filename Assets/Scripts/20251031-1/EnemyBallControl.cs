using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallControl : MonoBehaviour
{
    private List<EnemyBall> enemyBalls = new List<EnemyBall>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void StopAllBalls()
    {
        var balls = this.transform.GetComponentsInChildren<EnemyBall>();

        foreach(var ball in balls)
        {
            ball.Stop();
        }
    }

    public void ReduceEnemyBall(int count)
    {
        var balls = this.transform.GetComponentsInChildren<EnemyBall>();

        if(count >= balls.Length)
        {
            foreach(var ball in balls)
            {
                ball.Dead();
            }
        }
        else
        {
            foreach(var ball in balls)
            {
                ball.Dead();

                count--;

                if(count <= 0)
                {
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
