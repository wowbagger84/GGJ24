using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroPunch : MonoBehaviour
{
	public List<List<string>> jokes;
	public GameObject punchPrefab;
	public GameObject jokeLinePrefab;
	public Transform punchSpawn;

	public List<string> joke;
	public int jokeLineIndex = 0;

	float lineCooldown = 0.1f;
	//float punchCooldown = 0.3f; //Extra cooldown for punchlines
	float timer = 0;

	AudioManager audioManager;

	public bool intro = false;

	public GameObject myLight;

	// Start is called before the first frame update
	void Start()
	{
		if (!intro)
		{
			string path = "Text/jokes";
			jokes = ParseJokes(path);
			joke = jokes[Random.Range(0, jokes.Count)];
		}
		else
		{
			//We are in the intro scene
			lineCooldown = 0.5f;
			//punchCooldown = 10;
			jokes = new List<List<string>>();
			var joke2 = new List<string>();
			joke2.Add("It's dark in here...");
			joke2.Add("Wait, I have an I Idea!");
			joke2.Add("Oh f*ck!");
			joke2.Add("The last joke of the game...");
			joke2.Add("...and there is no punchline!");
			joke2.Add("");
			jokes.Add(joke2);
			joke = jokes[Random.Range(0, jokes.Count)];
		}
		audioManager = FindFirstObjectByType<AudioManager>();
	}

	List<List<string>> ParseJokes(string filePath)
	{
		List<List<string>> parsedJokes = new List<List<string>>();
		var jokeLines = new List<string>();

		foreach (var line in Resources.Load<TextAsset>(filePath).ToString().Split('\n'))
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
		if (Input.GetButtonDown("Fire1") && timer > lineCooldown)
		{
			//spawn the next joke line or punchline
			if (jokeLineIndex < joke.Count - 1)
			{
				var newLine = Instantiate(jokeLinePrefab, punchSpawn.position, transform.rotation);
				newLine.GetComponent<Bubble>().text = joke[jokeLineIndex];
				newLine.GetComponent<Bubble>().Init();
				if (jokeLineIndex == 2)
				{
					myLight.SetActive(true);
					audioManager?.audios.PlayMonster(gameObject);
				}
				if (jokeLineIndex == 4)
				{
					Invoke(nameof(LightsOut), 3f);
					Invoke(nameof(EndGame), 4f);
				}
				jokeLineIndex++;
				timer = 0;
				audioManager?.audios.PlayPunchlineAppear(gameObject);
			}
			else
			{
				//var newLine = Instantiate(punchPrefab, punchSpawn.position, transform.rotation);
				//newLine.GetComponent<Bubble>().text = joke[jokeLineIndex];

				//if (intro)
				//	newLine.GetComponent<Bubble>().ActivateGravity(1.8f);

				//newLine.GetComponent<Bubble>().Init();

				//jokeLineIndex = 0;
				//joke = jokes[Random.Range(0, jokes.Count)];
				//timer = -punchCooldown;
				//audioManager?.audios.PlayPunchlinePunch(gameObject);
			}

		}

		timer += Time.deltaTime;
	}

	private void LightsOut()
	{
		myLight.SetActive(false);
	}

	private void EndGame()
	{
		SceneManager.LoadScene("Credits");
	}
}
