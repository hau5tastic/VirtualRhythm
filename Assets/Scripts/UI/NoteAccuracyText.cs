using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteAccuracyText : MonoBehaviour {

    bool activated = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (activated == true)
        {
            transform.localScale *= 1.01f;
        }
	}

    public void ActivateText(string t, Color c)
    {
        //GetComponent<Animation>().Play();
        //Start the coroutine timer (reset it if running already) to allow the text some time to stay before disappearing
        StopCoroutine("WaitBeforeDisappear");
        StartCoroutine("WaitBeforeDisappear");
        transform.localScale = Vector3.one;
        activated = true;
        GetComponent<Text>().enabled = true;
        GetComponent<Text>().text = t;

        GetComponent<Text>().color = c;
    }

    public IEnumerator WaitBeforeDisappear()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Text>().enabled = false;
    }
}

