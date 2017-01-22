    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLight : MonoBehaviour {

    public PlayerScript playerScript;
    public int index;
    TriggerBoxes triggerBox;
    Light spotLight;

	// Use this for initialization
	void Start () {
        spotLight = GetComponent<Light>();
        triggerBox = GetComponentInParent<TriggerBoxes>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerScript.triggerBoxes[index].highlighted || playerScript.triggerBoxes[index].highlighted2)
        {
            spotLight.color = triggerBox.GetSpriteColor();
            spotLight.enabled = true;
        }
        else
        {
            spotLight.enabled = false;
        }
	}
}
