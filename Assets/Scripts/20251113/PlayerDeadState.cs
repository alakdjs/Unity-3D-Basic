using UnityEngine;

public class PlayerDeadState : IState
{
    private PlayerController _player;

    public PlayerDeadState(PlayerController player)
    {
        _player = player;
    }

    public void Enter() //  상태 진입시 한번 실행
    {
        _player.Animator.SetTrigger("Dead");

        // 물리 비활성화
        _player.Rigidbody.linearVelocity = Vector3.zero;
        _player.Rigidbody.useGravity = false;

        // 콜라이더 비활성화
        Collider collider = _player.GetComponent<Collider>();

        if (collider != null) 
        { 
            collider.enabled = false;
        }
    }

    public void Execute()  // 상태 유지시 반복 실행
    {

    }

    public void Exit()  // 상태 종료시 한번 실행
    {

    }


}
