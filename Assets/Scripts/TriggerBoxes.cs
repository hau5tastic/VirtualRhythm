using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerBoxes : MonoBehaviour {

    public bool highlighted = false; //Becomes active when the joystick aims towards it
    public bool highlighted2 = false; //Becomes active when the other joystick aims towards it

    public PlayerScript pScript;

    public Vector2 highlightReq; //This is the value which will check input in order to highlight the panel
    public bool collidedWithNote = false;
    private GameObject note;

    private SpriteRenderer sprite;

	// Use this for initialization
	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        HighlightState();

        //Check if the collider is a note
        if (note != null && collidedWithNote == true)
        {
            //If purple highlight
            if (highlighted == true && highlighted2 == true)
            {
                //Due to the natural human inability to press both buttons at the exact same time, we need to have multiple
                //conditional branches to allow one button to be pressed and then the other to register the hit
                if (Input.GetButtonDown("Left Fire") && Input.GetButtonDown("Right Fire"))
                {
                    //Process destroying the note
                    if (note.tag == "Note" || note.tag == "Purple Note")
                        DestroyNote(note);
                }
                else if (Input.GetButton("Left Fire"))
                {
                    //Process destroying the note
                    if (Input.GetButtonDown("Right Fire"))
                        if (note.tag == "Note" || note.tag == "Purple Note")
                            DestroyNote(note);
                }
                else if (Input.GetButton("Right Fire"))
                {
                    //Process destroying the note
                    if (Input.GetButtonDown("Left Fire"))
                        if (note.tag == "Note" || note.tag == "Purple Note")
                            DestroyNote(note);
                }
            }
            else if (highlighted == true) //blue highlight
            {
                if (Input.GetButtonDown("Left Fire"))
                {
                    //Process destroying the note
                    if (note.tag == "Note" || note.tag == "Blue Note")
                        DestroyNote(note);
                }

            }
            else if (highlighted2 == true) //orange highlight
            {
                if (Input.GetButtonDown("Right Fire"))
                {
                    //Process destroying the note
                    if (note.tag == "Note" || note.tag == "Orange Note")
                        DestroyNote(note);
                }
            }
        }
    }

    //This method will check joystick input to highlight the panels
    void HighlightInput()
    {
        if (pScript.stickInput.x != 0 && pScript.stickInput.y != 0)
        {
            //If a right panel
            if (highlightReq.x > 0)
            {
                //No vertical
                if (highlightReq.y == 0)
                {
                    if (pScript.stickInput.x > 0.5f)
                        highlighted = true;
                }
                else if (highlightReq.y > 0)
                {
                    if (pScript.stickInput.x > 0.5f && pScript.stickInput.y > 0.5f);
                }
            }
        }
    }

    void HighlightState()
    {
        if (highlighted == true && highlighted2 == true)
        {
            //turn purple
            //GetComponent<Renderer>().material.color = Color.magenta;
            sprite.color = Color.magenta;
        }
        else if (highlighted == true)
        {
            //turn blue
            //GetComponent<Renderer>().material.color = Color.blue;
            sprite.color = Color.blue;
        }
        else if (highlighted2 == true)
        {
            //turn orange
            //GetComponent<Renderer>().material.color = new Color(1, 0.55f, 0, 1);
            sprite.color = new Color(1, 0.55f, 0, 1);
        }
        else if (highlighted == true && highlighted2 == true)
        {
            //turn purple
            //GetComponent<Renderer>().material.color = Color.magenta;
            sprite.color = Color.magenta;
        }
        else
        {
            //turn white
            //GetComponent<Renderer>().material.color = Color.white;
            sprite.color = Color.white;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        collidedWithNote = true;
        note = c.gameObject;
    }

    void OnTriggerExit2D(Collider2D c)
    {
        collidedWithNote = false;
        note = null;
    }

    void OnTriggerStay2D(Collider2D c)
    {
        /*
        //Check if the collider is a note
        if (c.tag == "Note")
        {
            //Debug.Log("Collided");
            if (highlighted == true)
            {
                if (Input.GetButtonDown("Left Fire"))
                {
                    //Process destroying the note
                    DestroyNote(c.gameObject);
                }

            }
            else if (highlighted2 == true)
            {
                if (Input.GetButtonDown("Right Fire"))
                {
                    //Process destroying the note
                    DestroyNote(c.gameObject);
                }
            }
        }
        */
    }

    void DestroyNote(GameObject note)
    {
        //Check the distance between the note and the panel
        float distance = Vector2.Distance(transform.position, note.transform.position);
        if (distance < 0.1f)
        {
            Debug.Log("Perfect!");
        }
        else if (distance < 0.25f)
        {
            Debug.Log("Great!");
        }
        else if (distance < 0.5f)
        {
            Debug.Log("Good!");
        }
        else if (distance < 1)
        {
            Debug.Log("Ok");
        }
        //Destroy the note
        Destroy(note.gameObject);
    }
}
