using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtNorth : MonoBehaviour
{
	void Start()
	{
		Input.location.Start();
	}

	void Update()
	{
		transform.localEulerAngles = Vector3.up * -Input.compass.trueHeading;
	}
}