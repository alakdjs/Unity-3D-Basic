using UnityEngine;

public class PlayerMoveState : IState
{
    private PlayerController _player;

    public PlayerMoveState(PlayerController player)
    {
        _player = player;
    }

    public void Enter()
    {
        _player.Animator.SetBool("Run", true);
    }

    public void Execute()
    {
        Vector2 input = _player.GetMoveInput();

        //  이동입력이 없는 경우에 Idle상태로 전환
        if (input.magnitude < 0.1f)
        {
            _player.StateMachine.ChangeState(_player.IdleState);
        }

        _player.Move(input);

        _player.CheckDead();

        if (_player.GetBaseAttackInput())
        {
            _player.StateMachine.ChangeState(_player.BasicAttackState);
        }
    }

    public void Exit() 
    {
        _player.Animator.SetBool("Run", false);
    }
}
