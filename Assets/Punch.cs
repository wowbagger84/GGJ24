using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
	public GameObject punchPrefab;
	public GameObject jokeLinePrefab;
	public Transform punchSpawn;

	//TODO: read/parse the text from the punchline system, scriptable object?
	//TODO: cycle jokes, so all have been used before repeating

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			//TODO: spawn the next joke line or punchline

			Instantiate(punchPrefab, punchSpawn.position, transform.rotation);
		}
	}
}
