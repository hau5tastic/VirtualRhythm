using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour {

	public float h1;
	public float h2;
	public float v1;
	public float v2;

	// Update is called once per frame
	void Update () {
		v1 = Input.GetAxis ("Vertical");
		h1 = Input.GetAxis ("Horizontal");
		v2 = Input.GetAxis ("Horizontal");
		h2 = Input.GetAxis ("Horizontal");

	}
}
