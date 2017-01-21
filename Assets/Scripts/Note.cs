using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

	void Start() {
		//Destroy (gameObject, 1.8f);
	}

	void Update () {
		transform.Translate ((Vector2.down * 5) * Time.deltaTime);
	}


	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag ("Player"))
			Destroy (gameObject);
	}
}
