using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	public string LevelName;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(LevelName);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{

	}
}
