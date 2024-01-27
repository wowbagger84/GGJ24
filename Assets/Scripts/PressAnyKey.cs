using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
	public string SceneToLoad = "Controls";
	// Start is called before the first frame update
	void Start()
	{
		transform.DOScale(1.1f, 0.5f).SetLoops(-1, LoopType.Yoyo);
	}

	private void Update()
	{
		if (Input.anyKeyDown)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(SceneToLoad);
		}
	}

	private void OnDestroy()
	{
		transform.DOKill();
	}
}
