using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCheck : MonoBehaviour
{
	public GameObject keyboardControls;
	public GameObject controllerControls;

	// Start is called before the first frame update
	void Start()
	{
		string[] joystickNames = Input.GetJoystickNames();

		for (int i = 0; i < joystickNames.Length; i++)
		{
			if (!string.IsNullOrEmpty(joystickNames[i]))
			{
				Debug.Log("Gamepad found: " + joystickNames[i]);
				keyboardControls.SetActive(false);
				controllerControls.SetActive(true);
			}
		}
	}

}
