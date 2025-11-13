using UnityEngine;

public class StateMachine
{
    private IState _currentState;

    public void ChangeState(IState newState)
    {
        if(_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;

        if(_currentState != null)
        {
            _currentState.Enter();
        }
    }

    public void Update()
    {
        /*
      if (_currentState != null)
      {
         _currentState.Execute();
      }
      */

        _currentState?.Execute();
    }

    public IState GetCurrentState()
    {
        return _currentState;
    }
}
