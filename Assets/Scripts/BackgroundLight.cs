using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLight : MonoBehaviour {

    public SpectrumAnalyzer spectrumAnalyzer;
    Light pulseLight;
    int highestBand;
    Color color = Color.white;
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
        pulseLight = GetComponent<Light>();
        defaultPos = pulseLight.transform.position;
        
	}
	
	void Update () {
        pulseLight.color = Color.Lerp(pulseLight.color, colors[desiredColor], elapsed);
        pulseLight.transform.position = Vector3.Lerp(pulseLight.transform.position, pulseLight.transform.position + -Vector3.forward * 1.5f, elapsed);
        if (elapsed > bpm/60)
        {
            ChangeColor();
            elapsed = 0.0f;
            pulseLight.transform.position = defaultPos;
        }
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
