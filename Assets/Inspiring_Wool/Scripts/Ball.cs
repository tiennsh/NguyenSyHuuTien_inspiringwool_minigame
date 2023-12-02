using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float force;
    [SerializeField] private float gravity;

    private IEnumerator perforated;


    private void OnEnable()
    {
        perforated = IsPerforated(15f);
        UIGamePlay.OnThrow += Throw;
    }

    private void OnDisable()
    {
        UIGamePlay.OnThrow -= Throw;
    }

    private void FixedUpdate()
    {
        if (rigidbody.velocity.y >= 0 && transform.position.y <= camera.position.y) return;
        camera.position = new Vector3(camera.position.x, transform.position.y, camera.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            HitBasket(GameManager.Ins.pointSave);
            GameManager.Ins.SaveBasket(collision.transform, true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Basket") && rigidbody.velocity.y < 0)
        {
            HitBasket(collision.transform);
            GameManager.Ins.SaveBasket(collision.transform);
        }

        if (collision.gameObject.CompareTag("Perforated") && rigidbody.velocity.y < 0)
        {
            HitBasket(collision.transform);
            GameManager.Ins.SaveBasket(collision.transform);
            StartCoroutine(perforated);
        }

        
    }

    public void _Init()
    {
        gameObject.SetActive(true);
        HitBasket(GameManager.Ins.pointSave);
        camera.position = new Vector3(0, 0, camera.position.z);
    }

    public void Throw()
    {
        transform.SetParent(null);
        rigidbody.velocity = Vector2.up * force;
        rigidbody.gravityScale = gravity;
    }

    public void HitBasket(Transform collision)
    {
        StopCoroutine(perforated);
        rigidbody.velocity = Vector2.zero;
        rigidbody.gravityScale = 0f;
        transform.SetParent(collision);
        transform.localPosition = new Vector3(0, 0.3f, 0);
    }

    IEnumerator IsPerforated(float _time)
    {
        yield return new WaitForSeconds(_time);
        transform.SetParent(null);
        rigidbody.velocity = Vector2.zero;
        rigidbody.gravityScale = gravity;

    }
}
