using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LoudText : MonoBehaviour {

	void Start () {
		Destroy (gameObject, 0.5f);
	}

	void Update() {
		transform.localScale *= 1.01f;
	}

	public void SetText(string s) {
		GetComponent<Text> ().text = s;
	}

	public void SetColor(Color c) {
		GetComponent<Text> ().color = c;
	}

}
