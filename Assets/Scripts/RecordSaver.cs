using System.Collections.Generic;
using UnityEngine;

public class RecordSaver : MonoBehaviour
{
    [SerializeField] private DirectionController directionController;
    [SerializeField] private int amountOfRecords = 10;
    private const string recordsKey = "recordsKey";
    private const char spliter = '|';
    private List<float> records = new List<float>();
    private float startTime;

    public List<float> Records => records;

    //save all record use PlayerPrefs in string, if need take record, need separete string to array
    private void Start()
    {
        directionController.RaceEnded += SaveRecord;
        string record = PlayerPrefs.GetString(recordsKey);

        if (!string.IsNullOrEmpty(record))
        {
            string[] recordFromPrefs = record.Split(spliter);

            //Convert string to float
            for (int i = 0; i < recordFromPrefs.Length; i++)
            {
                if (!string.IsNullOrEmpty(recordFromPrefs[i]))
                {
                    records.Add(float.Parse(recordFromPrefs[i]));
                }
            }

            SortRecords();
        }
    }

    public void GameStarted()
    {
        startTime = Time.timeSinceLevelLoad;
    }

    private void SaveRecord()
    {
        directionController.RaceEnded -= SaveRecord;
        float time = Time.timeSinceLevelLoad - startTime;

        if (records.Count < amountOfRecords)
        {
            records.Add(time);
            SortRecords();
        }
        else if (records.Count == amountOfRecords)
        {
            SortRecords();

            if (time < records[records.Count - 1])
            {
                records[records.Count - 1] = time;
                SortRecords();
            }
        }
        else
        {
            Debug.LogError("wrong amount of records if prefs");
        }

        string save = string.Empty;

        foreach (float record in records)
        {
            save = save + record.ToString() + spliter.ToString();
        }
        //Save all times in string, with pattern
        PlayerPrefs.SetString(recordsKey, save);
    }

    private void SortRecords()
    {
        for (int i = 0; i < records.Count; i++)
        {
            for (int j = 0; j < records.Count - 1; j++)
            {
                if (records[j] > records[j + 1])
                {
                    float temp = records[j + 1];
                    records[j + 1] = records[j];
                    records[j] = temp;
                }
            }
        }
    }
}
