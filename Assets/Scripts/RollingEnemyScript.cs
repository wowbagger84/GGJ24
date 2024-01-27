using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyScript : MonoBehaviour
{
    public float rollSpeed = 50f;
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    public GameObject deathEffect;
    ParticleSystem deathSplosion;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        deathSplosion = GetComponentInChildren<ParticleSystem>();
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
            var newEffect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            
            transform.DOScale(0, 0.3f).SetEase(Ease.InSine).OnComplete(() => Destroy(gameObject));
            
            deathSplosion.Play();
            animator.SetTrigger("Death");
            Destroy(newEffect, 1);
        }
    }
}
