using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private InitView _initView;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnClickPrevButton()
    {
        this.gameObject.SetActive(false);
        _initView.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
