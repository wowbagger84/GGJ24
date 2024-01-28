using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
	public GameObject explosion;

	// Start is called before the first frame update
	void Start()
	{

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Bubble"))
		{
			var effect = Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(effect, 1);
			FindFirstObjectByType<AudioManager>().audios.PlayWallSmash(gameObject);
			GetComponent<Collider2D>().enabled = false;
			GetComponent<SpriteRenderer>().enabled = false;

			Destroy(gameObject, 1);
		}
	}
}
