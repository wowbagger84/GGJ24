using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
	}
}
