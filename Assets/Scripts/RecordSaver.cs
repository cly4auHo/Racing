using System.Collections.Generic;
using UnityEngine;

public class RecordSaver : MonoBehaviour
{
    [SerializeField] private int amountOfRecords = 10;
    private const string recordsKey = "recordsKey";
    private const char spliter = '|';
    private List<int> records = new List<int>();

    public List<int> Records => records;

    //save all record use PlayerPrefs in string, if need take record, need separete string to array
    private void Start()
    {
        string record = PlayerPrefs.GetString(recordsKey);

        if (!string.IsNullOrEmpty(record))
        {
            string[] recordFromPrefs = record.Split(spliter);

            //Convert string to float
            for (int i = 0; i < recordFromPrefs.Length; i++)
            {
                if (!string.IsNullOrEmpty(recordFromPrefs[i]))
                {
                    records.Add(int.Parse(recordFromPrefs[i]));
                }
            }

            SortRecords();
        }
    }

    public void AddRecord(int score)
    {
        if (records.Count < amountOfRecords)
        {
            records.Add(score);
        }
        else if (records.Count == amountOfRecords)
        {
            SortRecords();

            if (score > records[records.Count - 1])
            {
                records[records.Count - 1] = score;
            }
        }
        else
        {
            Debug.LogError("wrong amount of records if prefs");
        }

        SortRecords();
        string save = string.Empty;

        foreach (int record in records)
        {
            save = save + record.ToString() + spliter.ToString();
        }

        //Save all scores in string, with pattern
        PlayerPrefs.SetString(recordsKey, save);
    }

    //sort from bigger to smaller
    private void SortRecords() 
    {
        for (int i = 0; i < records.Count; i++)
        {
            for (int j = 0; j < records.Count - 1; j++)
            {
                if (records[j] < records[j + 1])
                {
                    int temp = records[j + 1];
                    records[j + 1] = records[j];
                    records[j] = temp;
                }
            }
        }
    }
}
