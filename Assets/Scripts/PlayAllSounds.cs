using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAllSounds : MonoBehaviour
{
	AudioManager audioManager;
	// Start is called before the first frame update
	void Start()
	{
		audioManager = FindObjectOfType<AudioManager>();
		audioManager.audios.PlayPlayerRun(gameObject);
		audioManager.audios.PlayPlayerJump(gameObject);
		audioManager.audios.PlayPlayerDoubleJump(gameObject);
		audioManager.audios.PlayPlayerSpriteFlip(gameObject);
		audioManager.audios.PlayPunchlineAppear(gameObject);
		audioManager.audios.PlayPunchlinePunch(gameObject);
		audioManager.audios.PlayPunchlineDrop(gameObject);
		audioManager.audios.PlayEnemyRun(gameObject);
		audioManager.audios.PlayEnemyDeath(gameObject);
		audioManager.audios.StartMusic(gameObject);
		audioManager.audios.StopMusic(gameObject);
		SceneManager.LoadScene("Splash");
	}

}
