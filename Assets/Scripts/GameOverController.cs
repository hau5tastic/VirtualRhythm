using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    public CanvasGroup canvGroup;
    public float timer;
    public Text gameOverText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= 6)
        {
            if (gameOverText.color.a > 0)
            {
                gameOverText.color = new Color(1,0,0,gameOverText.color.a - 1 * Time.deltaTime);
            }
            else
                ReturnToMenu();
        }
        else if (canvGroup.alpha < 1)
        {
            canvGroup.alpha += 1 * Time.deltaTime;
        }
	}

    void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
