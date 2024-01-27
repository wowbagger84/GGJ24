using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
	public GameObject punchPrefab;
	public GameObject jokeLinePrefab;
	public Transform punchSpawn;

	public string[] joke;
	public int jokeLineIndex = 0;

	//TODO: read/parse the text from the punchline system, scriptable object?
	//TODO: cycle jokes, so all have been used before repeating

	// Start is called before the first frame update
	void Start()
	{
		joke = new string[] { "What do you call a fish with no eyes?", "A fsh!" };
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			//TODO: spawn the next joke line or punchline

			if (jokeLineIndex < joke.Length - 1)
			{
				var newLine = Instantiate(jokeLinePrefab, punchSpawn.position, transform.rotation);
				newLine.GetComponent<Bubble>().text = joke[jokeLineIndex];
				newLine.GetComponent<Bubble>().Init();
				jokeLineIndex++;
			}
			else
			{
				var newLine = Instantiate(punchPrefab, punchSpawn.position, transform.rotation);
				newLine.GetComponent<Bubble>().text = joke[jokeLineIndex];
				newLine.GetComponent<Bubble>().Init();
				jokeLineIndex = 0;
			}
		}
	}
}