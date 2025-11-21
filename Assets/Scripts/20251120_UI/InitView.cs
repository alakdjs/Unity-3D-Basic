using UnityEngine;

public class InitView : UIView
{
    [SerializeField] private GameView _gameView;

    public void OnClickStartButton()
    {
        Debug.Log("OnClickStartButton");
        this.gameObject.SetActive(false);
        UIManager.Instance.ShowGameView();
    }
}
