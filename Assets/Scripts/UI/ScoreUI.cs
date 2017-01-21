using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreUI : MonoBehaviour {

	static Text textScore;
	static int newScore;
	static int score;

	void Awake() {
		textScore = GetComponent<Text> ();
		score = 0;
		newScore = 0;
	}

	public static void Add(int value, int multiplier = 1) {
		newScore += value * multiplier;
		//UpdateUI ();
	}

	public static void Subtract(int value) {
		newScore -= value;
		//UpdateUI ();
	}

	public static void Set(int value) {
		newScore = value;
		// UpdateUI ();
	}

	static void UpdateUI() {
		textScore.text = "Score: " + score;
		// textScore.transform.localScale *= 1.01f;
	}

	void Update() {
		if (score < newScore) {
			score++;
			UpdateUI();
		} else if (score > newScore) {
			score--;
			UpdateUI ();
		}

	}

}
