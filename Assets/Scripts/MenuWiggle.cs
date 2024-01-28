using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuWiggle : MonoBehaviour
{
	public bool credits = false;

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

		var rects2 = FindObjectsOfType<TextMeshProUGUI>();

		float time2 = 0;
		foreach (var item in rects2)
		{
			if (item.transform.parent.GetComponent<Canvas>() != null)
			{
				if (credits)
					item.rectTransform.DOScale(1.03f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetDelay(Random.Range(0, time2)).SetUpdate(true);
				else
					item.rectTransform.DOScale(1.05f, 0.1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutElastic).SetDelay(Random.Range(0, time2));
				time2 += 0.1f;
			}
		}
	}

	private void OnDestroy()
	{
		DOTween.KillAll();
	}

}
