using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    //These variables retrieve the input value from 0 to 1
    public Vector2 stickInput;
    public Vector2 stickInput2;

    public TriggerBoxes[] triggerBoxes;

	public float health;

    // Use this for initialization
    void Start ()
    {
		health = 100f;
        //StartCoroutine("HighlightTriggerPanels2");
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetJoyInputs();
        HighlightTriggerPanels();

        for (int i = 0; i < triggerBoxes.Length; i++) //Use a script so we don not have to use GetComponent every frame
        {
            if (stickInput.x == (triggerBoxes[i].highlightReq.x) && stickInput.y == (triggerBoxes[i].highlightReq.y))
            {
                triggerBoxes[i].highlighted = true;
            }
            else
            {
                triggerBoxes[i].highlighted = false;
            }

            if (stickInput2.x == (triggerBoxes[i].highlightReq.x) && stickInput2.y == (triggerBoxes[i].highlightReq.y))
            {
                triggerBoxes[i].highlighted2 = true;
            }
            else
            {
                triggerBoxes[i].highlighted2 = false;
            }
        }

		if (health <= 0) {
			ScoreUI.Set (0);
		}
    }

    void GetJoyInputs()
    {
        //float deadzone = 0.25f;
        stickInput = new Vector2(Mathf.Round(Input.GetAxis("Horizontal")), Mathf.Round(Input.GetAxis("Vertical")));
        /*
        if (stickInput.magnitude < deadzone)
            stickInput = Vector2.zero;
        else
            stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));
            */
        stickInput2 = new Vector2(Mathf.Round(Input.GetAxis("Horizontal 2")), Mathf.Round(Input.GetAxis("Vertical 2")));
        /*
        if (stickInput.magnitude < deadzone)
            stickInput = Vector2.zero;
        else
            stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));
            */

    }

    void HighlightTriggerPanels()
    {
        /*
        //Top panel
        if (stickInput.y > 0.5f && stickInput2.y > 0.5f)
        {
            triggerBoxes[0].highlighted = true;
            triggerBoxes[0].highlighted2 = true;
        }
        else if (stickInput.y > 0.5f)
            triggerBoxes[0].highlighted = true;
        else if (stickInput2.y > 0.5f)
            triggerBoxes[0].highlighted2 = true;

        //Top Right panel
        
        if (stickInput.y > 0.5f && stickInput.x > 0.5f
            && stickInput2.y > 0.5f && stickInput2.x > 0.5f)
        {
            triggerBoxes[1].highlighted = true;
            triggerBoxes[1].highlighted2 = true;
        }
        else if (stickInput.y > 0.5f)
            triggerBoxes[1].highlighted = true;
        else if (stickInput2.y > 0.5f)
            triggerBoxes[1].highlighted2 = true;
            
        if (stickInput.x > 0.5f)
        {
            triggerBoxes[2].highlighted = true;
        }
        else
        {
            triggerBoxes[2].highlighted = false;
        }
        */
    }

    IEnumerator HighlightTriggerPanels2()
    {
        Debug.Log("Co started");
        while (true)
        {
            Debug.Log("Co running");
            for (int i = 0; i < triggerBoxes.Length; i++) //Use a script so we don not have to use GetComponent every frame
            {
                if (stickInput.x == triggerBoxes[i].highlightReq.x && stickInput.y == triggerBoxes[i].highlightReq.y)
                {
                    triggerBoxes[i].highlighted = true;
                }
                else
                {
                    triggerBoxes[i].highlighted = false;
                }
            }
            yield return null;
        }
    }

}



