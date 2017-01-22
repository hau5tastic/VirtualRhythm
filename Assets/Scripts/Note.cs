using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

	void Start() {
        //Destroy (gameObject, 1.8f);

        //Start the sound wave note size to 0
        transform.localScale = Vector3.zero;
	}

	void Update () {
		transform.Translate ((Vector2.down * 5) * Time.deltaTime);

        //Gradually scale the notes to become larger as they approach the player
        if (transform.localScale.x < 1)
            transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 2 * Time.deltaTime);
	}


	void OnTriggerEnter2D(Collider2D col) {
		PlayerScript player = col.gameObject.GetComponent<PlayerScript> ();
		if (player) {
			Destroy (gameObject);
			player.health -= 2;
		}


	}
}
