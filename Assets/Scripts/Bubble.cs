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
	bool coolDown = false;
	float time2 = 0.2f;
	bool activated = false;

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
			ActivateGravity(delay);
		}

		myCollider = GetComponent<BoxCollider2D>();

		//adjust time according to the length of the text
		size = text.Length * 8 + 30;

		DOTween.To(() => myFloat, x => myFloat = x, size / 60, time / 2).OnUpdate(UpdateCollider);

		GetComponentInChildren<TextMeshProUGUI>().DOText(text, time);

		if (jokeLine)
			GetComponentInChildren<Image>().GetComponent<RectTransform>().DOSizeDelta(new Vector2(size, 30), time).SetEase(Ease.OutSine);
		else
			GetComponentInChildren<Image>().GetComponent<RectTransform>().DOSizeDelta(new Vector2(size, 30), time / 2).SetEase(Ease.OutBack);
	}

	public void ActivateGravity(float delay)
	{
		if (activated)
			return;
		activated = true;
		Invoke(nameof(ActivateGravity), delay);
		transform.DOShakePosition(0.8f, 0.05f, 10, 90, false, false).SetDelay(delay - 0.8f);
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
		if (!collision.gameObject.CompareTag("Player") && !coolDown)
		{
			var rb2d = collision.gameObject.GetComponent<Rigidbody2D>();
			if (rb2d != null && time2 > 0)
				rb2d.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);

			coolDown = true;
			var effect = Instantiate(hitPrefab, collision.contacts[0].point, transform.rotation);
			Destroy(effect, 2);
			Invoke(nameof(ResetCoolDown), 0.5f);

			if (collision.gameObject.CompareTag("Dummy"))
			{
				FindFirstObjectByType<AudioManager>()?.audios.PlayEnemyDeath(gameObject);
			}
		}
	}

	private void ResetCoolDown()
	{
		coolDown = false;
	}

	private void OnDestroy()
	{
		transform.GetComponentInChildren<Image>().DOKill();
		transform.DOKill();
	}

	private void Update()
	{
		time2 -= Time.deltaTime;
	}
}
