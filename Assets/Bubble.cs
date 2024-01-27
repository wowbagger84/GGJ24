using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
	public float time = 0.4f;

	float myFloat = 0;
	BoxCollider2D myCollider;

	// Start is called before the first frame update
	void Start()
	{
		DOTween.To(() => myFloat, x => myFloat = x, 5, time).OnUpdate(UpdateCollider);

		myCollider = GetComponent<BoxCollider2D>();

		//TODO: adjust time according to the length of the text

		//TODO: Get the text from the punchline system.
		GetComponentInChildren<TextMeshProUGUI>().DOText("PUNCHLINE!", time);

		//TODO: Approximate the size of the text and set the size of the bubble accordingly
		GetComponentInChildren<Image>().GetComponent<RectTransform>().DOSizeDelta(new Vector2(300, 30), time).SetEase(Ease.OutBack).OnComplete(Cleanup);
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
}
