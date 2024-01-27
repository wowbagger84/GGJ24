using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
	public string SceneToLoad = "Controls";
	float cooldown = 0.8f;
	// Start is called before the first frame update
	void Start()
	{
		transform.DOScale(1.1f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetDelay(cooldown);
	}

	private void Update()
	{
		if (Input.anyKeyDown && cooldown < 0)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(SceneToLoad);
		}
		cooldown -= Time.deltaTime;
	}

	private void OnDestroy()
	{
		transform.DOKill();
	}
}
