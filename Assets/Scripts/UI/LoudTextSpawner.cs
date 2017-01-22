using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class LoudTextSpawner : MonoBehaviour {

	public GameObject loudTextPrefab;
    public RectTransform loudTextSpawnLocation;
	public void Spawn (string text, Color color) {
		GameObject loudText = Instantiate (loudTextPrefab) as GameObject;
		loudText.transform.SetParent (transform);
		loudText.gameObject.GetComponent<LoudText> ().SetText (text);
		loudText.gameObject.GetComponent<LoudText> ().SetColor (color);
		loudText.transform.position = loudTextSpawnLocation.position;
	}
}
