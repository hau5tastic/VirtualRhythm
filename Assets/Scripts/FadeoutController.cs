using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeoutController : MonoBehaviour {

    public CanvasGroup fadeGroup;
    public float timer;
    public float endSongTime;

    public ScoreUI score;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += 1 * Time.deltaTime;

        if (timer >= endSongTime)
        {
            fadeGroup.alpha += 0.2f * Time.deltaTime;

            if (fadeGroup.alpha >= 1)
            {
                //Change to results screen
                ChangeToResultsScreen();
            }
        }
	}

    void ChangeToResultsScreen()
    {
        SceneManager.LoadScene("Results");
    }
}
