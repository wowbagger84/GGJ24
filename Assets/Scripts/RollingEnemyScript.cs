using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyScript : MonoBehaviour
{
    public float rollSpeed = 50f;
    public float moveSpeed = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        rb.angularVelocity = rollSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            transform.DOScale(0, 0.3f).SetEase(Ease.InSine).OnComplete(() => Destroy(gameObject));
        }
    }
}
