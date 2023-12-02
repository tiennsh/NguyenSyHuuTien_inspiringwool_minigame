using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHome : UIBase
{
    public void _Init(bool _isShow = false)
    {
        if (!_isShow)
        {
            Close();
            return;
        }

        Open();
    }

    public void BtnPlay()
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
