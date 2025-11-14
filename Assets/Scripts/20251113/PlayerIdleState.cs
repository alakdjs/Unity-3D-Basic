using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerIdleState : IState
{
    private PlayerController _player;

    public PlayerIdleState(PlayerController player)
    {
        _player = player;
    }

    public void Enter() // 진입 시 한 번 실행
    {
        Debug.Log("IdleState Enter()");
    }

    public void Execute() // 반복 실행
    {
        Vector2 input = _player.GetMoveInput();

        if (input.magnitude > 0.1f)
        {
            _player.StateMachine.ChangeState(_player.MoveState);
        }

        _player.CheckDead();

        if (_player.GetBaseAttackInput())
        {
            _player.StateMachine.ChangeState(_player.BasicAttackState);
        }
    }

    public void Exit() // 탈출 시 한 번
    {
        Debug.Log("IdleStateExit()");
    }
}
