using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour {

	public GameObject notePrefab;
	public float spawnDistance;

	void Start() {
		SpawnNote2();
	}

	void SpawnNote () {
		transform.SetParent (transform);
		Vector3 spawnPosition = transform.up * spawnDistance;
		GameObject newNote = Instantiate (notePrefab);
		newNote.transform.position = spawnPosition;
		newNote.transform.rotation = transform.localRotation;
	}

    void SpawnNote2()
    {
        transform.SetParent(transform);
        Vector3 spawnPosition = transform.up * spawnDistance;
        GameObject newNote = Instantiate(notePrefab, transform.position, transform.rotation);
    }
}
