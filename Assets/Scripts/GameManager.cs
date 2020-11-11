using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private RecordSaver recordSaver;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject tableRecords;
    [Tooltip("must stay in order")]
    [SerializeField] private Text[] records;
    private bool isPause;

    private void Start()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        pause.SetActive(false);
        tableRecords.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
            isPause = true;
        }
    }

    public void Play()
    {
        scoreManager.GameStarted();
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowScore()
    {
        tableRecords.SetActive(true);
        menu.SetActive(false);
        int[] record = recordSaver.Records.ToArray();

        if (record.Length <= records.Length)
        {
            for (int i = 0; i < record.Length; i++)
            {
                records[i].text = record[i].ToString();
            }
        }
        else
        {
            Debug.LogError("wrong sizes list of records in ui or saver");
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
        isPause = false;
        pause.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}