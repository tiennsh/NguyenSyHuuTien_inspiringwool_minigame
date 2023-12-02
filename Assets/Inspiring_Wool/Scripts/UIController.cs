using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Ins;


    [SerializeField] private UIHome uiHome;
    [SerializeField] private UIGamePlay uiGamePlay;
    [SerializeField] private UIPopupRetry uiRetry;

    private StateUI stateUI;

    public StateUI StateUI
    {
        set
        {
            stateUI = value;
            uiHome._Init(stateUI == StateUI.home);
            uiGamePlay._Init(stateUI == StateUI.gamePlay);
            uiRetry._Init(stateUI == StateUI.retry);
        }

        get => stateUI;
    }

    private void Awake()
    {
        Ins = this;

    }


}

public enum StateUI
{
    home,
    gamePlay,
    retry,
}
