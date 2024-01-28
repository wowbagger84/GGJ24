using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class EnemyScript : MonoBehaviour
{
	public float rollSpeed = 50f;
	public float moveSpeed = 2f;
	private Rigidbody2D rb;
	private bool canPlayAudio = true;
	public GameObject deathEffect;
	public int distanceToPlayer;
	ParticleSystem deathSplosion;
	Animator animator;
	Vector3 startPos;
	AudioManager audioManager;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		startPos = transform.position;
		deathSplosion = GetComponentInChildren<ParticleSystem>();
		audioManager = FindObjectOfType<AudioManager>();
	}

	void Update()
	{
		distanceToPlayer = (int)Vector2.Distance(transform.position, FindObjectOfType<PlayerController>().transform.position);
		rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
		rb.angularVelocity = rollSpeed;

		if (transform.position.y < -30)
		{
			rb.velocity = Vector2.zero;
			transform.position = startPos;
		}


	}

	async void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Bubble"))
		{
			var newEffect = Instantiate(deathEffect, transform.position, Quaternion.identity);

			transform.DOScale(0, 0.3f).SetEase(Ease.InSine).OnComplete(() => Destroy(gameObject));

			//deathSplosion.Play();
			//animator.SetTrigger("Death");
			Destroy(newEffect, 1);
		}

		if (canPlayAudio && distanceToPlayer < 20)
		{
			audioManager.audios.PlayBounce(gameObject);
			canPlayAudio = false;
			Invoke(nameof(ResetAudioCooldown), 1f);
		}
	}

	private void ResetAudioCooldown()
	{
		canPlayAudio = true;
	}
}
