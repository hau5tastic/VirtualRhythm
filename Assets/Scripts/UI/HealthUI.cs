using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

	PlayerScript player;
	Slider slider;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript>();
		slider = GetComponent<Slider> ();
	}

	void Update() {
		slider.value = player.health / 100f;
	}
}
