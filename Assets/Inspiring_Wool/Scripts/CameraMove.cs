using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("DeathZone"))
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
