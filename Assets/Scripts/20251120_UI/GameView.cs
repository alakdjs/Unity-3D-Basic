using UnityEngine;

public class GameView : UIView
{

    public void OnClickPrevButton()
    {
        UIManager.Instance.PreUIView();
    }

    public void OnClickOptionPopUp()
    {
        UIManager.Instance.ShowOptionPopUp();
    }

    public void OnClickQuitButton()
    {
        UIManager.Instance.ShowEndingView();
    }

}
