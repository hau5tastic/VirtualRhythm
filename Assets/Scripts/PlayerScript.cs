using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    //These variables retrieve the input value from 0 to 1
    public float horizontalInput;
    public float verticalInput;
    public float horizontalInput2;
    public float verticalInput2;

    public Vector2 stickInput;
    public Vector2 stickInput2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        horizontalInput2 = Input.GetAxis("Horizontal 2");
        verticalInput2 = Input.GetAxis("Vertical 2");


        float deadzone = 0.25f;
        stickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (stickInput.magnitude < deadzone)
            stickInput = Vector2.zero;
        else
            stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));

        stickInput2 = new Vector2(Input.GetAxis("Horizontal 2"), Input.GetAxis("Vertical 2"));
        if (stickInput.magnitude < deadzone)
            stickInput = Vector2.zero;
        else
            stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));
    }
}
