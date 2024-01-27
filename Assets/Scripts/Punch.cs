using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Punch : MonoBehaviour
{
	public List<List<string>> jokes;
	public GameObject punchPrefab;
	public GameObject jokeLinePrefab;
	public Transform punchSpawn;

	public List<string> joke;
	public int jokeLineIndex = 0;

	//TODO: read/parse the text from the punchline system, scriptable object?
	//TODO: cycle jokes, so all have been used before repeating

	// Start is called before the first frame update
	void Start()
	{
		string path = "Assets/Jokes/jokes.txt";
		jokes = ParseJokes(path);
		joke = jokes[Random.Range(0, jokes.Count)];
	}

	List<List<string>> ParseJokes(string filePath)
	{
		List<List<string>> parsedJokes = new List<List<string>>();
		var jokeLines = new List<string>();

		foreach (var line in File.ReadLines(filePath))
		{
			if (string.IsNullOrWhiteSpace(line))
			{
				if (jokeLines.Count > 0)
				{
					parsedJokes.Add(new List<string>(jokeLines));
					jokeLines.Clear();
				}
			}
			else
			{
				jokeLines.Add(line);
			}
		}

		if (jokeLines.Count > 0)
		{
			parsedJokes.Add(new List<string>(jokeLines));
		}

		return parsedJokes;
	}


	// Update is called once per frame
	void Update()
	{
		
		if (Input.GetButtonDown("Fire1"))
		{
			//TODO: spawn the next joke line or punchline
			
			if (jokeLineIndex < joke.Count - 1)
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
				joke = jokes[Random.Range(0, jokes.Count)];
			}
		}
	}
}
