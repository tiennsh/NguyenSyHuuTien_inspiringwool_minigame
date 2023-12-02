using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baskets : MonoBehaviour
{
    [SerializeField] private List<Basket> lstBaskets;
    [SerializeField] private float speed;

    private void OnEnable()
    {
        GameManager.OnChaengScore += SetBasket;
    }

    private void OnDisable()
    {
        GameManager.OnChaengScore -= SetBasket;
    }

    public void _Init()
    {
        for (int i = 0; i<= lstBaskets.Count; i++)
        {
            if (i >= lstBaskets.Count) return;
            lstBaskets[i]?.gameObject.SetActive(true);
        }

    }

    public void SetBasket()
    {
        /*int _index = GameManager.Ins.Score / 10 + 2;
        if (_index >= lstBaskets.Count) return;
        lstBaskets[_index]?.gameObject.SetActive(true);*/
    }
}
