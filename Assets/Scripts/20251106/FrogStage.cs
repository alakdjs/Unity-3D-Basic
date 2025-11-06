using UnityEngine;


public class FrogStage : MonoBehaviour
{
    [SerializeField] private Transform _CubeParentTr;

    private bool _CubeClear = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FrogGameMain.Instance.SetAction(Jump);
    }

    public void Jump()
    {
        var cubeObjs = _CubeParentTr.GetComponentsInChildren<FrogCube>();

        foreach (var cubeObj in cubeObjs)
        {
            cubeObj.Jump();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_CubeClear)
            return;

        if (_CubeParentTr.GetComponentsInChildren<FrogCube>().Length <= 0)
        {
            _CubeClear = true;
            FrogGameMain.Instance.NextStage();
        }
    }
}
