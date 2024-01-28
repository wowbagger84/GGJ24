using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCheck : MonoBehaviour
{
	public GameObject keyboardControls;
	public GameObject controllerControls;

	private bool connected = false;

	IEnumerator CheckForControllers()
	{
		while (true)
		{
			var controllers = Input.GetJoystickNames();

			if (!connected && controllers.Length > 0)
			{
				connected = true;
				Debug.Log("Connected");
				keyboardControls.SetActive(false);
				controllerControls.SetActive(true);

			}
			else if (connected && controllers.Length == 0)
			{
				connected = false;
				Debug.Log("Disconnected");
				keyboardControls.SetActive(true);
				controllerControls.SetActive(false);
			}

			yield return new WaitForSeconds(1f);
		}
	}

	void Awake()
	{
		StartCoroutine(CheckForControllers());
	}

	// Start is called before the first frame update
	void Start()
	{
		//string[] joystickNames = Input.GetJoystickNames();
		//Debug.Log("Joysticks found: " + joystickNames.Length);
		//for (int i = 0; i < joystickNames.Length; i++)
		//{
		//	if (!string.IsNullOrEmpty(joystickNames[i]))
		//	{
		//		Debug.Log("Gamepad found: " + joystickNames[i]);
		//		keyboardControls.SetActive(false);
		//		controllerControls.SetActive(true);
		//	}
		//}

		//if (joystickNames.Length > 0)
		//{
		//	//Debug.Log("Gamepad found: " + joystickNames[0]);
		//	keyboardControls.SetActive(false);
		//	controllerControls.SetActive(true);
		//}

	}

}
