using UnityEngine;

public class PlayerBasicAttackState : IState
{
    PlayerController _player;
    AnimatorStateInfo _stateInfo;

    public PlayerBasicAttackState(PlayerController player)
    {
        _player = player;
    }

    public void Enter() // 진입
    {
        _player.Animator.SetTrigger("Attack");
    }

    public void Execute() // 반복
    {
        _stateInfo = _player.Animator.GetCurrentAnimatorStateInfo(0);

        // 현재 Attack 애니메이션이 진행중인지 확인
        if (_stateInfo.IsName("MeleeAttack_OneHanded"))
        {
            // Attack 애니메이션이 진행 중일때 처리할 로직

            if (_stateInfo.normalizedTime >= 0.95f)
            {
                // 애니메이션이 끝나기 직전에 처리할 로직
                Vector2 input = _player.GetMoveInput();

                if (input.magnitude > 0.1f) // 입력이 있었으면
                {
                    _player.StateMachine.ChangeState(_player.MoveState);
                }
                else
                {
                    _player.StateMachine.ChangeState(_player.IdleState);
                }
            }

        }

    }

    public void Exit() // 탈출
    {

    }
}
