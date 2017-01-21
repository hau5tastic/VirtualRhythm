using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {


	void Update () {
		transform.Translate (transform.up * 0.2f);
	}
}
