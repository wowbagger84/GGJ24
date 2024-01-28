using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
	public GameObject deathEffect;
	AudioManager audioManager;
	// Start is called before the first frame update

	private void Start()
	{
		audioManager = FindObjectOfType<AudioManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			//collision.gameObject.GetComponent<Player>().Die();
			Invoke(nameof(ReloadScene), 1f);
			var newEffect = Instantiate(deathEffect, (collision.transform.position + transform.position) / 2, Quaternion.identity);
			var newEffect2 = Instantiate(deathEffect, collision.transform.position + transform.up, Quaternion.identity);
			Destroy(newEffect, 1f);
			Destroy(newEffect2, 1f);
			collision.gameObject.GetComponent<PlayerController>().enabled = false;
			collision.gameObject.GetComponent<Punch>().enabled = false;
			collision.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;

			//Todo: Add death sound
			audioManager.audios.PlayPlayerDeath(gameObject);
		}
		if (collision.gameObject.CompareTag("Dummy"))
		{
			var newEffect = Instantiate(deathEffect, (collision.transform.position + transform.position) / 2, Quaternion.identity);
			Destroy(newEffect, 1f);
			Destroy(collision.gameObject);
		}
	}

	private void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
