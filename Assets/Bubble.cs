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

	public GameObject hitPrefab;

	float myFloat = 0;
	BoxCollider2D myCollider;
	float size = 0;

	// Start is called before the first frame update
	public void Init()
	{
		if (jokeLine)
		{
			Destroy(gameObject, 10);
			transform.DOMoveY(transform.position.y + 2, time * jokeLineTime).SetEase(Ease.InSine);
			transform.GetComponentInChildren<Image>().DOFade(0, time * jokeLineTime / 2).SetDelay(jokeLineTime / 2).SetEase(Ease.InSine);
			GetComponentInChildren<TextMeshProUGUI>().DOFade(0, time * jokeLineTime / 2).SetDelay(jokeLineTime / 2).SetEase(Ease.InSine);
		}
		else
		{
			Invoke(nameof(CleanUp), 20);
			float delay = Random.Range(3f, 5f);
			Invoke(nameof(ActivateGravity), delay);
			transform.DOShakePosition(0.8f, 0.05f, 10, 90, false, false).SetDelay(delay - 0.8f);
		}

		myCollider = GetComponent<BoxCollider2D>();

		//adjust time according to the length of the text
		size = text.Length * 8 + 30;

		DOTween.To(() => myFloat, x => myFloat = x, size / 60, time).OnUpdate(UpdateCollider);

		GetComponentInChildren<TextMeshProUGUI>().DOText(text, time);

		if (jokeLine)
			GetComponentInChildren<Image>().GetComponent<RectTransform>().DOSizeDelta(new Vector2(size, 30), time).SetEase(Ease.OutSine);
		else
			GetComponentInChildren<Image>().GetComponent<RectTransform>().DOSizeDelta(new Vector2(size, 30), time / 2).SetEase(Ease.OutBack);
	}

	private void CleanUp()
	{
		if (Vector3.Distance(FindFirstObjectByType<PlayerController>().transform.position, transform.position) > 20)
			Destroy(gameObject);
		else
			Invoke(nameof(CleanUp), 20);
	}

	private void UpdateCollider()
	{
		myCollider.offset = new Vector2(myFloat / 2, 0.2f);
		myCollider.size = new Vector2(myFloat, 0.5f);
	}

	void ActivateGravity()
	{
		GetComponent<Rigidbody2D>().isKinematic = false;
		FindFirstObjectByType<AudioManager>()?.audios.PlayPunchlineDrop(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!collision.gameObject.CompareTag("Player"))
		{
			var effect = Instantiate(hitPrefab, collision.contacts[0].point, transform.rotation);
			Destroy(effect, 2);
		}
	}

	private void OnDestroy()
	{
		transform.GetComponentInChildren<Image>().DOKill();
		transform.DOKill();
	}
}
