using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
	public Light2D flickeringLight;
	public float minIntensity = 0.5f;
	public float maxIntensity = 1.5f;
	public float flickerSpeed = 1.0f;

	private void Start()
	{
		if (flickeringLight == null)
		{
			flickeringLight = GetComponent<Light2D>();
		}

		// Start the flickering coroutine
		StartCoroutine(Flicker());
	}

	IEnumerator Flicker()
	{
		while (true)
		{
			// Randomly adjust the light intensity within the specified range
			flickeringLight.intensity = Random.Range(minIntensity, maxIntensity);

			// Wait for a short duration
			yield return new WaitForSeconds(Random.Range(0.1f, 0.3f) / flickerSpeed);
		}
	}

}
