using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopupRetry : UIBase
{
    [SerializeField] private Text txtScore;
    [SerializeField] private Text txtBestScore;


    public void _Init(bool _isShow = false)
    {
        if (!_isShow)
        {
            Close();
            return;
        }

        Prefs.bestScore = GameManager.Ins.Score;
        txtScore.text = "" + GameManager.Ins.Score;
        txtBestScore.text = "" + Prefs.bestScore;
        Open();
    }   
    
    public void BtnRetry()
    {
        GameManager.Ins.PlayGame();
        
    }

    public override void Open()
    {
        base.Open();
    }

    public override void Close()
    {
        base.Close();
    }
}
