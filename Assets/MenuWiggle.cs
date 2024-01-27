using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MenuWiggle : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		var rects = FindObjectsOfType<Image>();

		float time = 0;
		foreach (var item in rects)
		{
			item.rectTransform.DOScale(1.05f, 0.1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutElastic).SetDelay(Random.Range(0, time));
			time += 0.1f;
		}
	}

	private void OnDestroy()
	{
		DOTween.KillAll();
	}

}
