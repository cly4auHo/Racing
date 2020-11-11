using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private RecordSaver recordSaver;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject tableRecords;
    [Tooltip("must stay in order")]
    [SerializeField] private Text[] records;

    private void Start()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        pause.SetActive(false);
        tableRecords.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pause.activeSelf)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
    }

    public void Play()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        recordSaver.GameStarted();
    }

    public void ShowScore()
    {
        tableRecords.SetActive(true);
        menu.SetActive(false);
        float[] record = recordSaver.Records.ToArray();
        
        for (int i = 0; i < record.Length; i++)
        {
            records[i].text = record[i].ToString();
        }

        if (record.Length < records.Length)
        {
            for (int i = record.Length; i < records.Length; i++)
            {
                records[i].text = "0";
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}