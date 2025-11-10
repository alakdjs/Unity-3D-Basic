using UnityEngine;


public class FrogStage : MonoBehaviour
{
    [SerializeField] private Transform _CubeParentTr;

    private FrogCube[] frogCubes;

    bool _isJump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FrogGameMain.Instance.SetAction(Jump);
    }

    public void Jump()
    {
        frogCubes = _CubeParentTr.GetComponentsInChildren<FrogCube>();

        foreach (var cubeObj in frogCubes)
        {
            cubeObj.Jump();
        }

        _isJump = true;
    }

    /// <summary>
    /// 점프한 큐브의 현재 상태를 체크한다.
    /// 하나라도 점프상태면 게임이 진행중.
    /// </summary>
    private bool GetJumpStateCubes()
    {
        foreach(var cubeObj in frogCubes)
        {
            if(cubeObj != null)
            {
                if(cubeObj.CurrentState == FrogCube.State.Jump)
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    ///  게임이 클리어 되었는지 체크
    /// </summary>
    private bool IsClear()
    {
        foreach (var cube in frogCubes)
        {
            if (cube != null)
            {
                return false;
            }
        }

        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isJump)
        {

            if (!GetJumpStateCubes())   //  점프 상태가 아니면
            {
                if (IsClear()) // 클리어 상태인지 체크
                {
                    // 게임 클리어상태
                    FrogGameMain.Instance.InvokeNextStage();
                    _isJump = false;
                }
                else
                {
                    // 게임 넌클리어상태
                    FrogGameMain.Instance.PlayGame();
                    _isJump = false;

                }
            }

        }
    }
}
