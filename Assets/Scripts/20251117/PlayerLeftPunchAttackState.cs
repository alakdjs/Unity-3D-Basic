using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftPunchAttackState : IState
{
    PlayerController _player;
    AnimatorStateInfo _stateInfo;
    private float _attackTimer;
    private float _attackAnimTime = 1.0f;

    public PlayerLeftPunchAttackState(PlayerController player)
    {
        _player = player;
    }

    public void Enter() //  진입
    {
        _player.Animator.SetTrigger("Attack");
        _player.Animator.SetInteger("AttackType", 3);

        _attackTimer = 0.0f;
    }

    public void Execute() // 반복
    {
        /*
        _stateInfo = _player.Animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log("----------------PunchLeft--------------");

        // 현재 Attack 애니메이션이 진행중인지 확인
        if (_stateInfo.IsName("PunchLeft"))
        {
           // Attack 애니메이션이 진행 중일때  처리할 로직
           Debug.Log("PunchLeft--------------");
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
        */

        _attackTimer += Time.deltaTime;

        //  애니메이션 시간
        if (_attackTimer >= _attackAnimTime)
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

    public void Exit() // 탈출
    {

    }

}
