using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bubble : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		transform.localScale = new Vector3(0, 1, 1);
		transform.DOScaleX(5, 0.15f).SetEase(Ease.OutBack).OnComplete(Cleanup);
		//GetComponentInChildren<TextMeshProUGUI>().DOText("PUNCHLINE!", 0.3f, true, ScrambleMode.All);
	}


	void Cleanup()
	{
		Destroy(gameObject, 1);
	}
	//private void Update()
	//{
	//	if (Input.GetButtonDown("Fire1"))
	//	{
	//		Start();
	//	}
	//}
}
