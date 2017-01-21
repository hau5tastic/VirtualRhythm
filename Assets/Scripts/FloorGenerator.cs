using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour {

	public GameObject floorTilePrefab;
	public Vector2 size;
	public float offset;

	float tileSize;

	void Start () {
		tileSize = floorTilePrefab.GetComponent<Renderer> ().bounds.size.x + offset;
		// Debug.Log (tileSize);
		Generate ();
	}

	void Generate() {
		for (int y = 0; y < size.y; ++y) {
			for (int x = 0; x < size.x; ++x) {
				Vector3 spawnPos = new Vector3(transform.position.x + x * tileSize, transform.position.y + y * tileSize, transform.position.z);
				GameObject tile = Instantiate (floorTilePrefab, spawnPos, Quaternion.identity) as GameObject;
				tile.transform.SetParent (transform);
			}
		}
	}
}
