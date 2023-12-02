using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : UIBase
{
    public static event Action OnThrow;
    [SerializeField] private Text txtScore;
    [SerializeField] private List<Image> lstHat;


    private void OnEnable()
    {
        GameManager.OnChaengScore += SetTxtScore;
        GameManager.OnChaengTurn += SetLstHat;

    }

    private void OnDisable()
    {
        GameManager.OnChaengScore -= SetTxtScore;
        GameManager.OnChaengTurn -= SetLstHat;
    }

    public void _Init(bool _isShow = false)
    {
        if (!_isShow)
        {
            Close();
            return;
        }
        SetTxtScore();
        SetLstHat();

        Open();
    }

    public void SetTxtScore()
    {
        if(txtScore)
            txtScore.text = "" + GameManager.Ins.Score;
    }

    public void SetLstHat()
    {
        for(int i=0; i<lstHat.Count; i++)
        {
            lstHat[i].gameObject.SetActive(i < GameManager.Ins.CountTurn);
        }
    }

    public void BtnThrow()
    {
        OnThrow?.Invoke();
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
