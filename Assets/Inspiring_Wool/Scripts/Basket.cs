using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private bool isMove;
    [SerializeField] private float speedMove;
    


    private void FixedUpdate()
    {
        if (!isMove) return;
        if ((transform.localPosition.x > GameManager.Ins.bound.y -0.5f && speedMove > 0) || (transform.localPosition.x < GameManager.Ins.bound.x + 0.5f && speedMove < 0))
            speedMove *= -1;

        transform.localPosition += Vector3.right * speedMove * Time.deltaTime;
    }
}
