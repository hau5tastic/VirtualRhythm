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

    //private GameObject note;
    private Queue<GameObject> notes;

    private SpriteRenderer sprite;

	LoudTextSpawner loudTextSpawner;
    public NoteAccuracyText accuracyText; //Appears when you land a hit on a note

	// Use this for initialization
	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        notes = new Queue<GameObject>();
		loudTextSpawner = GameObject.Find("Canvas"). GetComponent<LoudTextSpawner> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
        HighlightState();

        //Check if the collider is a note
        if (notes.Count != 0 && collidedWithNote == true)
        {
            //If purple highlight
            if (highlighted == true && highlighted2 == true)
            {
                //Due to the natural human inability to press both buttons at the exact same time, we need to have multiple
                //conditional branches to allow one button to be pressed and then the other to register the hit
                if (Input.GetButtonDown("Left Fire") && Input.GetButtonDown("Right Fire"))
                {
                    //Process destroying the note
                    if (notes.Peek().tag == "Note" || notes.Peek().tag == "Purple Note")
                        DestroyNote(notes.Dequeue());
                }
                else if (Input.GetButton("Left Fire"))
                {
                    //Process destroying the note
                    if (Input.GetButtonDown("Right Fire"))
                        if (notes.Peek().tag == "Note" || notes.Peek().tag == "Purple Note")
                            DestroyNote(notes.Dequeue());
                }
                else if (Input.GetButton("Right Fire"))
                {
                    //Process destroying the note
                    if (Input.GetButtonDown("Left Fire"))
                        if (notes.Peek().tag == "Note" || notes.Peek().tag == "Purple Note")
                            DestroyNote(notes.Dequeue());
                }
            }
            else if (highlighted == true) //blue highlight
            {
                if (Input.GetButtonDown("Left Fire"))
                {
                    //Process destroying the note
                    if (notes.Peek().tag == "Note" || notes.Peek().tag == "Blue Note")
                        DestroyNote(notes.Dequeue());
                }

            }
            else if (highlighted2 == true) //orange highlight
            {
                if (Input.GetButtonDown("Right Fire"))
                {
                    //Process destroying the note
                    if (notes.Peek().tag == "Note" || notes.Peek().tag == "Orange Note")
                        DestroyNote(notes.Dequeue());
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
        notes.Enqueue(c.gameObject);
    }

    void OnTriggerStay2D(Collider2D c)
    {
        //float distance = Vector2.Distance(transform.position, c.transform.position);

        //if (distance < 0.025f)
            //Debug.Log(c.GetComponent<Note>().timer);
    }

    void OnTriggerExit2D(Collider2D c)
    {
        collidedWithNote = false;
        if(notes.Count != 0)
        {
            notes.Dequeue();
        }      
    }

    void DestroyNote(GameObject note)
    {
        //Check the distance between the note and the panel
        float distance = Vector2.Distance(transform.position, note.transform.position);
        if (distance < 0.125f)
        {
            // Debug.Log("Perfect!");
            //loudTextSpawner.Spawn ("Perfect!", Color.red);
            accuracyText.ActivateText("Perfect!", Color.red);
			ScoreUI.Add (100);
            Debug.Log(note.GetComponent<Note>().timer);
        }
        else if (distance < 0.25f)
        {
            // Debug.Log("Great!");
            //loudTextSpawner.Spawn ("Great!", Color.green);
            accuracyText.ActivateText("Great!", Color.green);
            ScoreUI.Add (50);
        }
        else if (distance < 0.5f)
        {
            // Debug.Log("Good!");
            //loudTextSpawner.Spawn ("Good.", Color.cyan);
            accuracyText.ActivateText("Good.", Color.cyan);
            ScoreUI.Add (25);
        }
        else if (distance < 1)
        {
            // Debug.Log("Ok");
            //loudTextSpawner.Spawn ("Ok...", Color.gray);
            accuracyText.ActivateText("Ok...", Color.gray);
            ScoreUI.Add (10);

            //Also damage the player due to poorly timed hit
            pScript.health -= note.GetComponent<Note>().damage;
        }
        //Destroy the note
        Destroy(note.gameObject);
    }

    public Color GetSpriteColor()
    {
        return sprite.color;
    }
}
