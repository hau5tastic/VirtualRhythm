using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class SpectrumAnalyzer : MonoBehaviour {

    public GameObject spawns;
    Transform[] spawnPoints;

    public float startScale = 1.0f;
    public float scaleMultiplier = 1.5f;

    AudioSource audioSource;
    float[] spectrum;
    float[] spectrumBand;
    float[] bandBuffer;
    float[] bufferDecrease;
    bool useBuffer = true;
    float[] highestFreqBand;
    float[] audioBand;
    float[] audioBandBuffer;


    void Start () {
        spectrum = new float[1024];
        spectrumBand = bandBuffer = bufferDecrease = highestFreqBand = audioBand = audioBandBuffer = new float[8];
        Transform[] tmpSpawnPoints = spawns.GetComponentsInChildren<Transform>();
        spawnPoints = new Transform[8];
       GameObject[] tmp = GameObject.FindGameObjectsWithTag("Spawn");

        for (int i = 0; i < tmp.Length; i++)
        {
            spawnPoints[i] = tmp[i].GetComponent<Transform>();
        }
        audioSource = GetComponent<AudioSource>();
	}

    void Update()
    {
        MakeFrequencyBands();
        BandBuffer();
        //NormalizeAudioBands();

        Debug.Log(spawnPoints.Length);
        for(int i = 1; i < spawnPoints.Length; i++)
        {
            if(useBuffer)
            {
                spawnPoints[i].localScale = new Vector3(1.0f, (bandBuffer[i] * scaleMultiplier) + startScale, 1.0f);
            }
            else
            {
                spawnPoints[i].localScale = new Vector3(1.0f, (spectrumBand[i] * scaleMultiplier) + startScale, 1.0f);
            }            
        }
    }

    void MakeFrequencyBands()
    {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);

        int count = 0;
        for(int i = 0; i < 8; i++)
        {
            float average = 0.0f;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            for(int j = 0; j < sampleCount; j++)
            {
                average += spectrum[count] * (count + 1);
                count++;
            }

            average /= count;
            spectrumBand[i] = average * 10;
        }
    }

    void BandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if (spectrumBand[i] > bandBuffer[i])
            {
                bandBuffer[i] = spectrumBand[i];
                bufferDecrease[i] = 0.005f;
            }

            if (spectrumBand[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.2f;
            }
        }
    }

    void NormalizeAudioBands()
    {
        for(int i = 0; i < 8; i++)
        {
            if(spectrumBand[i] > highestFreqBand[i])
            {
                highestFreqBand[i] = spectrumBand[i];
            }
            audioBand[i] = spectrumBand[i] / highestFreqBand[i];
            audioBandBuffer[i] = bandBuffer[i] / highestFreqBand[i];
        }
    }
}
