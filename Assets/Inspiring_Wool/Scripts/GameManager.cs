using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Ins;
    public static event Action OnChaengScore;
    public static event Action OnChaengTurn;

    [SerializeField] private Transform basketStart;
    [SerializeField] private Ball ball;
    [SerializeField] private Baskets baskets;

    public Transform pointSave;
    public Vector2 bound;

    int score;
    public int Score => score;

    int countTurn;
    public int CountTurn => countTurn;

    private void Awake()
    {
        Ins = this;
        SetBound();
    }



    public void PlayGame()
    {
        countTurn = 3;
        score = 0;
        pointSave = basketStart;
        UIController.Ins.StateUI = StateUI.gamePlay;
        ball._Init();
        baskets._Init();
    }

    public void SaveBasket(Transform _basket, bool _isDeathZone = false)
    {
        if(!_isDeathZone && CheckPoint(_basket))
        {
            score += 10;
            OnChaengScore?.Invoke();
        }    
        else
        {
            countTurn -= 1;
            OnChaengTurn?.Invoke();
            if(countTurn <=0)
            {
                UIController.Ins.StateUI = StateUI.retry;
                ball.gameObject.SetActive(false);
            }
        }    
    }


    private bool CheckPoint(Transform _newPoint)
    {
        if(pointSave == null)
        {
            pointSave = _newPoint;
            return true;
        }
        else if(pointSave != _newPoint)
        {
            pointSave = _newPoint;
            return true;
        }
        return false;
    }

    private void SetBound()
    {
        Vector2 _bound = new Vector2(Screen.width, Screen.height);
        _bound = Camera.main.ScreenToWorldPoint(_bound);
        bound = new Vector2(-_bound.x, _bound.x);
    }    
}
