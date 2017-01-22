using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLight : MonoBehaviour {

    public SpectrumAnalyzer spectrumAnalyzer;
    Light light;
    int highestBand;
    Color color, previousColor = Color.white;
    Vector3 defaultPos;

    Color[] colors =
    {
        Color.red,
        Color.blue,
        Color.cyan,
        Color.yellow,
        Color.green,
        Color.magenta
    };
    int desiredColor = 0;
    int bpm = 117;
    float elapsed = 0.0f;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        defaultPos = light.transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {

        light.color = Color.Lerp(light.color, colors[desiredColor], elapsed);
        light.transform.position = Vector3.Lerp(light.transform.position, light.transform.position + -Vector3.forward * 1.5f, elapsed);
        if (elapsed > bpm/60)
        {
            ChangeColor();
            elapsed = 0.0f;
            light.transform.position = defaultPos;
        }

        // Debug.Log(desiredColor);

        elapsed += Time.deltaTime;

    }

    void ChangeColor()
    {

        int index = Random.Range(0, 6);
        do
        {
            index = Random.Range(0, 6);
            desiredColor = index;
        } while (color == colors[index]);
    }
}
