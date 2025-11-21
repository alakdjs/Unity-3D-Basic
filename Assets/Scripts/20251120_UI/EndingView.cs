using UnityEngine;

public class EndingView : UIView
{
    public void OnclickPrevViewButton()
    {
        UIManager.Instance.PreUIView();
    }
}
