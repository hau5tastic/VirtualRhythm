using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour {

    public GameObject[] singleNotes; //White notes are more common, so they take up more slots
    public GameObject purpleNote;
    public Transform[] noteSpawners;

    public AnimationCurve animCurve;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnNote()
    {
        int selectedSpawn = Random.Range(0, 8);
        int selectedNote = Random.Range(0, 4);

        Instantiate(singleNotes[selectedNote], noteSpawners[selectedSpawn].transform.position, noteSpawners[selectedSpawn].transform.rotation);

        //Instantiate((selectedNote == 1) ? purpleNote : singleNotes[Random.Range(0, 1)],
        //  noteSpawners[Mathf.RoundToInt(selectedSpawn)].transform.position, noteSpawners[]);
    }

    public void SpawnDualNotes()
    {
        int selectedSpawn = Random.Range(0, 8);
        int selectedSpawn2 = Random.Range(0, 8);
        int selectedNote = Random.Range(0, 3);
        int selectedNote2 = Random.Range(0, 3);

        //Make sure the 2nd note is not the same color note as the other spawned one
        //2 white notes are allowed, but 2 of the same colored notes (eg. blue and blue) are not allowed
        while (selectedNote2 == selectedNote && selectedNote2 != 0)
        {
            selectedNote2 = Random.Range(0, 3);
        }

        //Don't let the 2 notes spawn on each other from the same spawn point
        while (selectedSpawn2 == selectedSpawn)
        {
            selectedSpawn2 = Random.Range(0, 8);
        }

        Instantiate(singleNotes[selectedNote], noteSpawners[selectedSpawn].transform.position, noteSpawners[selectedSpawn].transform.rotation);
        Instantiate(singleNotes[selectedNote2], noteSpawners[selectedSpawn2].transform.position, noteSpawners[selectedSpawn2].transform.rotation);
    }

    public void SpawnPurpleNote()
    {
        int selectedSpawn = Random.Range(0, 8);
        Instantiate(purpleNote, noteSpawners[selectedSpawn].transform.position, noteSpawners[selectedSpawn].transform.rotation);
    }
}
