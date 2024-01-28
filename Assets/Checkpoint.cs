using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	public float levelID = 0;
	public float index = 0;
	// Start is called before the first frame update
	void Start()
	{
		if (PlayerPrefs.GetFloat("checkpoint" + levelID) == index && index != 0)
			FindFirstObjectByType<PlayerController>().transform.position = transform.position;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			PlayerPrefs.SetFloat("checkpoint" + levelID, index);
		}
	}
}
