using UnityEngine;

public class InitView : MonoBehaviour
{
    [SerializeField] private GameView _gameView;

    public void OnClickStartButton()
    {
        Debug.Log("OnClickStartButton");
        this.gameObject.SetActive(false);
        _gameView.gameObject.SetActive(true);
    }
}
