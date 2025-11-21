using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionPopUp : UIView
{
    [SerializeField] private Image _DimBackground;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public override void Show()
    {
        _DimBackground.gameObject.SetActive(true);
        base.Show();
    }

    public override void UnShow()
    {
        _DimBackground.gameObject.SetActive(false);
        base.UnShow();
    }

    public void OnClickOkButton()
    {
        UIManager.Instance.UnShowOptionPopUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
