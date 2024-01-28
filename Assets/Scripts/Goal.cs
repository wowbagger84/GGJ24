using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	public string nextLevelName = "Credits";

	// Start is called before the first frame update
	void Start()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevelName);
		}
	}
}
