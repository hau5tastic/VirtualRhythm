using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralPlatform : MonoBehaviour {

	public GameObject lanePrefab;
	public float radius;
	public int numberOfLanes;

	Lane[] lanes;

    public Lane[] lanes2;

	void Awake() {
		lanes = new Lane[numberOfLanes];
		for (int i = 0; i < numberOfLanes; ++i) {
			//CreateLane (i);
		}
	}

	void Update () {
		
	}

	void CreateLane(int index) {
		GameObject newLane = Instantiate(lanePrefab);
		lanes [index] = newLane.GetComponent<Lane> ();
		newLane.transform.SetParent (transform);
		float x0 = transform.position.x;
		float y0 = transform.position.y;
		float angle = (index * 360f / numberOfLanes) * Mathf.Deg2Rad;
		// Debug.Log (angle);
		newLane.transform.localPosition = new Vector2 (x0 + radius * Mathf.Cos(angle), y0 + radius * Mathf.Sin(angle));
		newLane.transform.rotation = Quaternion.Euler (0f, 0f,  index * 360f / numberOfLanes);
	}


}
