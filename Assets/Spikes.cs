using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
	public GameObject deathEffect;
	// Start is called before the first frame update
	void Start()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			//AudioManager audioManager = FindObjectOfType<AudioManager>();
			//audioManager.audios.PlayPlayerDeath(gameObject);
			//collision.gameObject.GetComponent<Player>().Die();
			Invoke(nameof(ReloadScene), 1f);
			var newEffect = Instantiate(deathEffect, (collision.transform.position + transform.position) / 2, Quaternion.identity);
			Destroy(newEffect, 1f);
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
