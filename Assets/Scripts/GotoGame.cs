using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoGame : MonoBehaviour {

    float elapsed = 0f;
	
	// Update is called once per frame
	void Update () {
        elapsed += Time.deltaTime;
        
        if(elapsed > 2.5f)
        {
            Application.LoadLevel("Test");
        }
	}
}
