using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
	public GameObject punchPrefab;
	public Transform punchSpawn;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Instantiate(punchPrefab, punchSpawn.position, transform.rotation);
		}
	}
}
