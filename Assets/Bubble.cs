using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
	public float time = 0.4f;
	public float jokeLineTime = 8f;
	public bool jokeLine = false;
	public string text = "PUNCHLINE!";

	float myFloat = 0;
	BoxCollider2D myCollider;
	float size = 0;

	// Start is called before the first frame update
	void Start()
	{

		DOTween.To(() => myFloat, x => myFloat = x, 5, time).OnUpdate(UpdateCollider);

		if (jokeLine)
		{
			Destroy(gameObject, 10);
			transform.DOMoveY(transform.position.y + 2, time * jokeLineTime).SetEase(Ease.InSine).OnComplete(() => Destroy(gameObject));
			transform.GetComponentInChildren<Image>().DOFade(0, time * jokeLineTime / 2).SetDelay(jokeLineTime / 2).SetEase(Ease.InSine);
			GetComponentInChildren<TextMeshProUGUI>().DOFade(0, time * jokeLineTime / 2).SetDelay(jokeLineTime / 2).SetEase(Ease.InSine);
		}

		myCollider = GetComponent<BoxCollider2D>();

		//adjust time according to the length of the text
		size = text.Length * 8 + 30;

		GetComponentInChildren<TextMeshProUGUI>().DOText(text, time);

		if (jokeLine)
			GetComponentInChildren<Image>().GetComponent<RectTransform>().DOSizeDelta(new Vector2(size, 30), time).SetEase(Ease.OutSine).OnComplete(Cleanup);
		else
			GetComponentInChildren<Image>().GetComponent<RectTransform>().DOSizeDelta(new Vector2(size, 30), time).SetEase(Ease.OutBack).OnComplete(Cleanup);
	}

	private void UpdateCollider()
	{
		myCollider.offset = new Vector2(myFloat / 2, 0.2f);
		myCollider.size = new Vector2(myFloat, 0.5f);
	}

	void Cleanup()
	{
		Destroy(gameObject, 2);
	}

	private void OnDestroy()
	{
		DOTween.KillAll();
	}
}
