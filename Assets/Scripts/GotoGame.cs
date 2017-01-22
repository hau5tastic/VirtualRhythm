using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoGame : MonoBehaviour {

    float elapsed = 0f;
    public string nextScene;

	// Update is called once per frame
	void Update () {
        elapsed += Time.deltaTime;
        
        if(elapsed > 2.5f)
        {
            SceneManager.LoadScene(nextScene);
        }
	}
}
