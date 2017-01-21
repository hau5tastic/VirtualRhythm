using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {


	void Update () {
		transform.Translate ((Vector2.down * 5) * Time.deltaTime);
	}
}
