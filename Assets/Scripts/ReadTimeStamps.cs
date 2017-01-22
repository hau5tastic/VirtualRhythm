using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTimeStamps : MonoBehaviour
{

    public string timeStampPath;
    public string[] timestamps;
    public int timeStampIndex;
    public string noteTypePath;
    public string[] noteTypes;
    public float timer;

    NoteSpawner noteSpawner;

    public float latencySpawning = 2.124f;

    void Start()
    {
        timeStampPath = Application.dataPath + "/" + "Timestamp.txt";
        timeStampIndex = 0;
        StreamReader reader = new StreamReader(timeStampPath);
        string[] timeStampLines = File.ReadAllLines(timeStampPath);
        timestamps = timeStampLines;

        noteTypePath = Application.dataPath + "/" + "Timestamp_NoteTypes.txt";
        string[] noteTypeLines = File.ReadAllLines(noteTypePath);
        noteTypes = noteTypeLines;

        //timestamps = readText.Split(new char[] { '\n' });

        /*
        //string[] stringSeparators = new string[] { "\r\n" };
        string[] lines = readText.Split(new string[] { "\r\n" }, StringSplitOptions.None);

        foreach(string s in lines)
        {
            Debug.Log(s);
        }
        */
        reader.Close();

        noteSpawner = GetComponent<NoteSpawner>();

        timer = latencySpawning;
    }

    void Update()
    {
        if (timeStampIndex < timestamps.Length)
        {
            timer = Mathf.MoveTowards(timer, float.Parse(timestamps[timeStampIndex]), Time.deltaTime);

            if (Mathf.Approximately(timer, float.Parse(timestamps[timeStampIndex])))
            {
                if (timeStampIndex < timestamps.Length)
                {
                    if (noteTypes[timeStampIndex] == "1")
                        noteSpawner.SpawnNote();
                    else if (noteTypes[timeStampIndex] == "2")
                        noteSpawner.SpawnDualNotes();
                    else if (noteTypes[timeStampIndex] == "3")
                        noteSpawner.SpawnPurpleNote();
                    else
                        noteSpawner.SpawnNote();

                    timeStampIndex += 1;
                }
                else
                    return; //No more
            }
        }
    }
}
